using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.Models
{
    public class GioHang
    {
        Qlbanhang db = new Qlbanhang();
        public List<Sanpham> Items { get; set; } // Add this property
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }

        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang()
        {
            Items = new List<Sanpham>();
        }
        public GioHang(int Masp)
        {
            iMasp = Masp;
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masp == iMasp);

            if (sp != null)
            {
                sTensp = sp.Tensp;
                sAnhBia = sp.Anhbia;
                dDonGia = double.Parse(sp.Giatien.ToString());
                iSoLuong = 1;
            }
        }

        // Add a method to calculate total price
        public double TongTien()
        {
            return iSoLuong * dDonGia;
        }
    }
}