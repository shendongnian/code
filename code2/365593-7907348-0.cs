    public static string CreateXMLforEngineersByLinq(List<Engineers> lst) 
    { 
        string x = New XElement("Engineers", 
                       lst.Select(new XElement, "Engineer",
                          new XElement("LicenseID", s.LicenseID),
                          new XElement("LastName", s.LastName),
                          new XElement("FirstName", s.FirstName),
                          new XElement("MiddleName", s.MiddleName)
                       )
                   );
        return x.ToString();
    } 
