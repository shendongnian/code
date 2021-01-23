    var rows = from row in targetTable.Rows.AsEnumerable()
               select new XElement("tr", 
                    new XAttribute("align", "left"), 
                    new XAttribute("valign","top"),
                    from column in targetTable.Columns.AsEnumerable()
                    select new XElement("td", 
                        new XAttribute("align", "left"), 
                        new XAttribute("valign", "top"),
                        myRow[targetColumn.ColumnName].ToString()
                    )
               );
