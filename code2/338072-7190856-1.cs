    var rows = targetTable.Rows.AsEnumerable().Select(row => new XElement("tr", 
                    new XAttribute("align", "left"), 
                    new XAttribute("valign","top"),
                    targetTable.Columns.AsEnumerable().Select(column => new XElement("td", 
                        new XAttribute("align", "left"), 
                        new XAttribute("valign", "top"),
                        myRow[targetColumn.ColumnName].ToString()
                    ))
               ));
