    internal int IndexForSortingBySiteHeight
    {
       get
       {
          if(double.IsNaN(siteHeight) throw new ApplicationException();
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
        public Max
        {
           get { return siteDataItems[0]; // here's why a list won't work!
        }
    }
