    public class TrailerListProvider : UserControl
    {
        myDomainContext _dc;
        public myDomainContext DomainContext
        {
            set
            {
                _dc = value;
                _dc.Load<trailer>(_dc.GetTrailersQuery());
                
            }
        }
        public TrailerListProvider()
        {
            DomainContext = new myDomainContext ();
        }
        public List<trailer> VendorList
        {
            get
            {
                return (from t in _dc.trailers
                        orderby t.trailerMark
                        select t).ToList();
            }
        }
    }
