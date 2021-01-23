    private static Dictionary<string , string >  DistinctInvoiceNumber(DataTable   VendorInvoiceStagingTable)
           {
               var InvoiceLinecollection = VendorInvoiceStagingTable.AsEnumerable().Select(t => new {  number = t.Field<string>(VendInvoice.Number),LineNumber = t.Field<string>(VendInvoice.LineNumber)}).ToDictionary();
            return InvoiceLinecollection;
          }
