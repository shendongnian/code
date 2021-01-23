    foreach (var invoiceGroup in groupedData)
    {
        string invoiceNumber = invoiceGroup.Key;
        decimal amount = invoiceGroup.First().Field<decimal>("Amount");
        headerTable.Rows.Add(invoiceNumber, amount);
        foreach (DataRow row in invoiceGroup)
        {
            lineTable.Rows.Add(
                    invoiceNumber,
                    row.Field<int>("LineNum"),
                    row.Field<decimal>("LineAmount"),
                    row.Field<string>("Ledger")
                );
        }
    }
