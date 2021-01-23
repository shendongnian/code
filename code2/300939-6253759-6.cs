            List<Thing> islemDetayKayitListesi = new List<Thing>();
            Thing a = new Thing() { GetSetDomainName = "abc.com", GetSetKayitNo = 1,
                GetSetKalanGun = 40 };
            Thing b = new Thing() { GetSetDomainName = "abc.com", GetSetKayitNo = 2, 
                GetSetKalanGun = 300 };
            Thing c = new Thing() { GetSetDomainName = "xyz.com", GetSetKayitNo = 3, 
                GetSetKalanGun = 400 };
            Thing d = new Thing() { GetSetDomainName = "123.com", GetSetKayitNo = 4, 
                GetSetKalanGun = 124 };
            islemDetayKayitListesi.Add(a);
            islemDetayKayitListesi.Add(b);
            islemDetayKayitListesi.Add(c);
            islemDetayKayitListesi.Add(d);
            var kayitlar3 =
                islemDetayKayitListesi.
                    Select(rows =>
                    new
                    {
                        KAYITNO = rows.GetSetKayitNo,
                        HESAPADI = rows.GetSetHesapAdi,
                        URUNNO = rows.GetSetUrunNo,
                        URUNADI = rows.GetSetUrunAdi,
                        URUNMIKTAR = rows.GetSetUrunMiktar,
                        ISLEMTARIHI = rows.GetSetIslemTarihi,
                        HIZMETDURUMU = rows.GetSetHizmetDurumu,
                        TOPLAMTUTAR = rows.GetSetToplamTutar,
                        HIZMETBASLANGICTARIHI = rows.GetSetHizmetBaslangicTarihi,
                        HIZMETBITISTARIHI = rows.GetSetHizmetBitisTarihi,
                        KALANGUN = rows.GetSetKalanGun,
                        DOMAINNAME = rows.GetSetDomainName,
                        SIPARISDURUMU = rows.GetSetSiparisDurumu
                    }).
                    GroupBy(anon =>
                        anon.DOMAINNAME).
                    Select(g =>
                        g.OrderByDescending(anon => anon.KALANGUN).First()).
                    AsQueryable();
            kayitlar3.ToList().
                ForEach(anon => Console.WriteLine("{0}, {1}, {2}", 
                    anon.KAYITNO, anon.DOMAINNAME, anon.KALANGUN));
        struct Thing 
        {
            public int GetSetKayitNo { get; set; }
            public int GetSetHesapAdi { get; set; }
            public int GetSetUrunNo { get; set; }
            public int GetSetUrunAdi { get; set; }
            public int GetSetUrunMiktar { get; set; }
            public int GetSetIslemTarihi { get; set; }
            public int GetSetHizmetDurumu { get; set; }
            public int GetSetToplamTutar { get; set; }
            public int GetSetHizmetBaslangicTarihi { get; set; }
            public int GetSetHizmetBitisTarihi { get; set; }
            public int GetSetKalanGun { get; set; }
            public string GetSetDomainName { get; set; }
            public int GetSetSiparisDurumu { get; set; }
        }
