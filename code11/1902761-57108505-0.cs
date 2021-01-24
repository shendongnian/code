    var BooksTask = _client.GetBooks(clientId);
    var ExtrasTask = _client.GetBooksExtras(clientId);
    var InvoicesTask = _client.GetBooksInvoice(clientId);
    var ReceiptsTask = _client.GetBooksRecceipts(clientId);
    model.Books = await BooksTask; 
    model.Extras = await ExtrasTask; 
    model.Invoices = await InvoicesTask; 
    model.Receipts = await ReceiptsTask; 
