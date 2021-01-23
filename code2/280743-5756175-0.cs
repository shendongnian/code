    public static double GetMevcutMiktar(string urunId,double acilisMiktari) 
            {
                double mevcutMiktar = 0;
    
                mevcutMiktar = acilisMiktari
                             - stok_getmiktar_byyapilanislem(urunId, "SATIS")
                return mevcutMiktar;
            }
