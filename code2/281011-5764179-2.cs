        private static IEnumerable<InvoiceLine>  DistinctInvoiceNumber(DataTable   VendorInvoiceStagingTable)
        {
            var InvoiceLinecollection = VendorInvoiceStagingTable
                                            .AsEnumerable()
                                            .Select(t => new InvoiceLine(t.Field<string>(VendInvoice.Number), t.Field<string>(VendInvoice.LineNumber)))
                                            .Distinct();
            return InvoiceLinecollection;
        }
