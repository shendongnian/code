    using System.Linq;
    class CompanyLicenseAccumulator
    {
        public Int32 Paios  { get; set; }
        public Int32 Papc   { get; set; }
        public Int32 Paplus { get; set; }
        // etc
    }
    static void Foo()
    {
        List<vwCompany> companies = ...
        GenericAccumulator<CompanyLicenseAccumulator,CompanyLicense> ca = new GenericAccumulator<CompanyLicenseAccumulator,CompanyLicense>( new CompanyLicenseAccumulator() );
        CompanyLicenseAccumulator summedValues = companies
            .Aggregate( ca ), ca.Next );
    }
