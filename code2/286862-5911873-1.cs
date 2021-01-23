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
        public static double FindMaxHeight(List<SiteData> objSite)
        {
            objSite.Sort(delegate(SiteData s1, SiteData s2) 
                                      {
                                          if (s1.SiteHeight > s2.SiteHeight)
                                              return 1;
                                          if (s1.SiteHeight < s2.SiteHeight)
                                              return -1;
                                          return 0;
                                      });
            return objSite[objSite.Count - 1].SiteHeight.Value;
        }
    }
