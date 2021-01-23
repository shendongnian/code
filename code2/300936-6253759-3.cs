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
        GroupBy(a => 
            //To ignore case and trailing/leading whitespace
            a.DOMAINNAME.ToUpper().Trim()).
        SelectMany(g => 
             g.OrderByDescending(a => a.KALANGUN).FirstOrDefault()).
        AsQueryable();
