        public static double FindMaxHeight<T>(List<T> objSite)
                where T : SiteData
        {
            objSite.Sort(delegate(T s1, T s2) 
                                      {
                                          if (s1.SiteHeight > s2.SiteHeight)
                                              return 1;
                                          if (s1.SiteHeight < s2.SiteHeight)
                                              return -1;
                                          return 0;
                                      });
            return objSite[objSite.Count - 1].SiteHeight.Value;
        }
