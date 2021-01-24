    // create a list for your invoices
    List<PurchaseInvoice> invoices = new List<PurchaseInvoice>();
    foreach (DataTable row in dtPurchaseInvoice.Rows)
    {                                     //   ^ Rows
        // create invoice
        PurchaseInvoice invoice = new PurchaseInvoice();
        
        // get an int
        invoice.PurchaseInvoiceNo = row.Field<int>("PurchaseInvoiceNo"); 
        // get a string
        invoice.CustomerName = row.Field<string>("CustomerName");
        // get a DateTime
        invoice.PurchaseDate = row.Field<DateTime>("PurchaseDate");
        // get a double
        invoice.PurchaseValue = row.Field<double>("PurchaseValue");
        // add invoice to list     
        invoices.Add(invoice);
    }
