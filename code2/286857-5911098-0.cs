    internal int IndexForSortingBySiteHeight
    {
       get
       {
          return (int)Math.Floor(siteHeight);
       }
    }
    public class ContainerForSortingBySiteHeight
    {
        private List<SiteData> siteDataItems;
        public void Add(SiteData datum)
        {
            if(datum == null) return;
            siteDataItems[datum.IndexForSortingBySiteHeight] = datum;
        }
    }
