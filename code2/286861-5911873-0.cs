    public class SiteData
    {
        private double? siteHeight;
        private double? siteWidth;
    
        public double? SiteHeight
        {
            get { return siteHeight; }
            set { siteHeight = value; }
        }
    
        public double? SiteWidth
        {
            get { return siteWidth; }
            set { siteWidth = value; }
        }
    
        public static double FindMaxHeight(IList<SiteData> objSite)
        {
            var lstSiteData = objSite.ToList();
    
            lstSiteData.Sort((s1, s2) =>
                                      {
                                          if (s1.SiteHeight > s2.SiteHeight)
                                              return 1;
    
                                          if (s1.SiteHeight < s2.SiteHeight)
                                              return -1;
    
                                          return 0;
                                      });
            return lstSiteData[lstSiteData.Count - 1].SiteHeight.Value;
        }
    }
