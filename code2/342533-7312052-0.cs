    if (InvoiceAmount != invoices.InvoiceAmount)
    {
        invoices.InvoiceStatus = "Partly Paid";
    }
    else
    {
        invoices.InvoiceStatus = "Confirmed";
    }
    db.Entry(invoices).State = EntityState.Modified;
    
    var clientPayment = new ClientPayment();
    // Set clientPayment properties
    db.ClientPayments.Add(clientPayment);
    
    db.SaveChanges();
