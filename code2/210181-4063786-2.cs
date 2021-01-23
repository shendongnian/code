    List<InvoicePart> Invoices =
         (from p in entities.InvoiceCards
          where (p.CustomerCard.ID == CustomerID)
          select ...
    
    // update the grid
    var bs = new BindingSource();
    bs.DataSource = Invoices;
    invoiceCardDataGridView.DataSource = bs;
