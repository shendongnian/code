    public static string CreateXMLforEngineersByLinq(List<Engineers> lst)
    {
        var x = new StringBuilder();
        x.AppendLine("<Engineers>)";
        x.Append(
                    string.Join(
                                 "\n",
                                 lst.Select(s =>
                                    string.Format(
                                               "<Engineer>\n<LicenseID>{0}</LicenseID>\n<LastName>{1}</LastName>\n<FirstName>{2}</FirstName>\n<MiddleName>{3}</MiddleName>\n</Engineer>\n", 
                                                s.LicenseID, 
                                                s.LastName, 
                                                s.FirstName, 
                                                s.MiddleName
                                                )
                                  ).ToArray()
                            );
          x.AppendLine("</Engineers>");
          return x.ToString();
  
    }
