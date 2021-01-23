    public class CompaniesConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new CompaniesConfiguration();
            XmlNode xCompanies = section.SelectSingleNode("Companies");
            if (xCompanies == null)
                throw new ConfigurationErrorsException("Companies node not found");
            config.Companies = CreateCompanies(xCompanies);
            return config;
        }
        
        private static CompanyConfiguration[] CreateCompanies(XmlNode xCompanies)
        {
            var nodes = xCompanies.SelectNodes("Company");
            return nodes == null ?
                       new CompanyConfiguration[0]
                       : nodes.Cast<XmlNode>().Select(ReadCompany).ToArray();
        }
    
        private static CompanyConfiguration ReadCompany(XmlNode xCompany)
        {
            var company = new CompanyConfiguration();
            if (!((XmlElement) xCompany).HasAttribute("name"))
                throw new ConfigurationErrorsException("Company node must have name attribute", xCompany);
            company.Name = ((XmlElement) xCompany).GetAttribute("name");
            var codes = (XmlElement)xCompany.SelectSingleNode("Codes");
            company.Codes = ReadCodes(codes);
            return company;
        }
    
        private static string[] ReadCodes(XmlNode xElement)
        {
            XmlNodeList xItems = xElement.SelectNodes("Code");
            return xItems == null ?
                                      new string[0]
                       : xItems
                             .Cast<XmlElement>()
                             .Where(xItem => xItem.HasAttribute("name"))
                             .Select(xItem => xItem.GetAttribute("name"))
                             .ToArray();
        }
    }
    public class CompanyConfiguration
    {
        public string Name { get; set; }
        public string[] Codes { get; set; }
    }
    
    public class CompaniesConfiguration
    {
        public CompanyConfiguration[] Companies { get; set; }
    }
