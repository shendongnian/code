    using System;
    
    namespace DataTablesExample
    {
        public class Company1
        {
            public int CompanyID { get; set; }
            public string CompanyName { get; set; }
            public string CompanyCode { get; set; }
            public int Wecare_companyId { get; set; }
            public int LicenseCount { get; set; }
            public bool active { get; set; }
            public int ModifiedBy { get; set; }
            public DateTime Lastmodifiedon { get; set; }
            //Adding a string datetime since it is easier to manipulate in backend
            public string Lastmodifiedonstring { get; set; }
        }
    }
