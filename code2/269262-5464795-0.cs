     public static Banner getSideBarBanner()
     {
        DataClassesDataContext db = new DataClassesDataContext();
        string thisPosition = EBannersPosition.siderbar.ToString();
        var bannerSiderBar 
            = db.Banners.FirstOrDefault<Banner>
                 (x => x.Position == thisPosition && x.Visible);
        return bannerSiderBar;
    }
