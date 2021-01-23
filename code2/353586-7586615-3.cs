    var invoice = Foo.GetLastInvoice( 32 );
    if (invoice != null)
    {
         var invoiceNumber = invoice.NumericInvoice;
         ...do something...
    }
    else
    {
         ...do something else...
    }
