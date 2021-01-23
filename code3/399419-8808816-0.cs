    public class Domain
    {
        ...
        public virtual IList<Company> Companies { get; private set; }
        public IList<Dealer> Dealers 
        { 
            get { return Companies.SelectMany(x => x.Dealers).Distinct(); }
        }
    }
    public class Company
    {
        ...
        public virtual IList<Domain> Domains { get; private set; }
        public virtual IList<Dealer> Dealers { get; private set; } 
    }
    public class Dealer
    {
        ...
        public virtual Company Company { get; private set; }
    }
