    var invoiceList = new List<string> { "123", "456", "789" };
    var invoices = GetInvoices(invoiceList);
    foreach(var i in invoices) {
      Console.WriteLine(i.SomeInvoiceProperty);
    }
