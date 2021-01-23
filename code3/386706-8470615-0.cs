    [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public static String FetchCountryList(int page, int rp, string sortname, string sortorder, string query, string qtype)
        {
            CountryBL CountryBLO = new CountryBL();
            XDocument xmlDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
    
                    new XElement("rows",
                        new XElement("page", page.ToString()),
                        new XElement("total", CountryBLO.Load().Count.ToString()),
                        CountryBLO.Load(page, rp, sortname, sortorder, query, qtype).Select(row => new XElement("row", new XAttribute("Id", row.Id.ToString()),
                                                          new XElement("cell", row.Name.ToString()),
                                                          new XElement("cell", row.Code.ToString()),
                                                          new XElement("cell", row.Capital.ToString()),
                                                          new XElement("cell", "<img id='imgEdit' lang='" + row.Id.ToString() + @"' style='cursor:pointer;border:0px;' src='../../Storage/Images/FlexGrid/edit.png' />
                                                                                <img id='imgDelete' lang='" + row.Id.ToString() + "' style='cursor:pointer;border:0px;' src='../../Storage/Images/FlexGrid/delete.gif' />")                        
                                                        )
                                    )
                        )
            );
    
    StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                doc.Save(writer);
            }
    
            return builder.ToString();
        }
