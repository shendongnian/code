    public class CustResult
    {
        public string custname {get;set;}
        public string company {get;set;} 
        public CustResult(Cust cust)
        {
            this.custname = cust.custname;
            this.company = cust.company;
        }
    }
