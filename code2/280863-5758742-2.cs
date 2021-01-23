    public class InvoiceGrouping
    {
         public string InvoiceNum { get; set; }
         public string InvoiceLineNum { get; set; }
    }
     var groupedData = from row in salesTable.AsEnumerable()                   
                       group row by new InvoiceGrouping
                       {
                            InvoiceNum = row.Field<string>("InvoiceNum"),
                            InvoiceLineNum = row.Field<string>("InvoiceLineNum")
                       }
                       into grp
                       select grp;
