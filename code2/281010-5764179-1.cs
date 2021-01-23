        private static IDictionary<string, string> DistinctInvoiceNumber(DataTable   VendorInvoiceStagingTable)
        {
            var InvoiceLinecollection = VendorInvoiceStagingTable
                                            .AsEnumerable()
                                            .Select(t => Tuple.Create(t.Field<string>(VendInvoice.Number), t.Field<string>(VendInvoice.LineNumber)))
                                            .Distinct()
                                            .ToDictionary(t => t.Item1, t => t.Item2);
            return InvoiceLinecollection;
        }
