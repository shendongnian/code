    string xml = @"<DB_company_5000>
                     <ID>3</ID>
                     <Name>Velin Ivan</Name>
                     <Adress>VamberskĂˇ 273</Adress>
                     <City>London 18</City>
                     <TEL>NULL</TEL>
                     <EXT>NULL</EXT>
                   </DB_company_5000>";
    xml = xml.Replace("<DB_company_5000>", "<table name=\"DB_company_5000\">");
    xml = xml.Replace("</DB_company_5000>", "</table>");
    xml = xml.Replace("<ID>", "<column name=\"ID\">");
    xml = xml.Replace("</ID>", "</column>");
    // ETC...
