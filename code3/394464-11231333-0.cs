        public partial class Tld
    {
        public override string ToString()
        {
            return this.Name;
        }    
    }
    
    public partial class Domain
    {
        public override string ToString()
        {
            return this.DomainName + "." +this.Tld.ToString();
        } 
        public  Domain (string domain, string tld):this( domain, new Tld(tld))
        {
          
        }
        public Domain(string domain, Tld tld):this()
        {
            this.DomainName = domain;
            this.Tld = tld;
            
        }
    }
    
    public partial class Url
    {
        public override string ToString()
        {
            return this.Scheme + "://" + this.Subdomain + this.Domain.ToString() + ((string.IsNullOrWhiteSpace(this.Path)) ? "" :  this.Path);
        }
        public Url (string scheme, string subdomain, string domain, string tld, string path):this(new Tld(tld),domain, subdomain,scheme,path){}
        public Url(Tld tld, string domainName, string subdomain, string scheme, string path): this(new Domain(domainName, tld),subdomain,scheme,path){}
        
         public Url(Domain domain, string subdomain, string scheme, string path):this()
        {
            this.Domain = domain;
            this.Path = path;
            this.Scheme = scheme;
            this.Subdomain = subdomain;
            
        }
    }
    public void Domain_Create_GOOD()
        {
         Domain expected = new Domain("google","co.nz");
           
        }
