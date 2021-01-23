                string xml = new XElement("inventory",
                    new XElement("item",
                        new XElement("name", "rock"),
                        new XElement("price", "5000")),
                    new XElement("item",
                        new XElement("name", "new car"),
                        new XElement("price", "1"))).ToString();
                
                DataTable dt = ParseXML(xml);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        Console.Write(row[col.ColumnName] + " | ");
                    Console.WriteLine();
                }
