    List<InvoicePart> Invoices =
         (from p in entities.InvoiceCards
          where (p.CustomerCard.ID == CustomerID)
          select new InvoicePart
          {
             InvoiceID = p.ID,
             InvoiceDatetime = p.DateTime,
             InvoiceTotal = (decimal) p.InvoiceTotal,
          }).ToList();
    
    // update the grid
    invoiceCardDataGridView.DataSource = Invoices;
