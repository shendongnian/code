       using(SqlConnection cn = new SqlConnection("data source=(local);initial catalog=pubs;.....")) {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM authors FOR XML AUTO, XMLDATA", cn);
 
            XmlReader xmlr = cmd.ExecuteXmlReader();
            xmlr.Read();
            while(xmlr.ReadState != ReadState.EndOfFile) {
                        Console.WriteLine(xmlr.ReadOuterXml());
            }                       
       }
