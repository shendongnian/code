        private static IEnumerable<Tuple<string, string>>  DistinctInvoiceNumber(DataTable   VendorInvoiceStagingTable)
        {
            var InvoiceLinecollection = VendorInvoiceStagingTable
                                            .AsEnumerable()
                                            .Select(t => Tuple.Create(t.Field<string>(VendInvoice.Number), t.Field<string>(VendInvoice.LineNumber)))
                                             .Distinct();
            return InvoiceLinecollection;
        }
