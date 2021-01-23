     public static string CreateXMLforEngineersTheSimpleWay(IEnumerable<Engineers> lst)
        {
            StringBuilder x = new StringBuilder();
            x.AppendLine("<Engineers>");
            foreach(var s in lst)
            {
                  x.AppendFormat("<Engineer>\n<LicenseID>{0}</LicenseID>\n<LastName>{1}</LastName>\n<FirstName>{2}</FirstName>\n<MiddleName>{3}</MiddleName>\n</Engineer>\n", 
                                 s.LicenseID, 
                                 s.LastName, 
                                 s.FirstName, 
                                 s.MiddleName);
            }
            x.AppendLine("</Engineers>");
            return x.ToString();
        }
