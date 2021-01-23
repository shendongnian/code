     var groupedData = from row in salesTable.AsEnumerable()                   
                       group row by new
                       {
                            InvoiceNum = row.Field<string>("InvoiceNum"),
                            InvoiceLineNum = row.Field<string>("InvoiceLineNum")
                       }
                       into grp
                       select grp;
