    public void DeleteInvoice(Guid id) {
        var invoice = this.SelectInvoiceById(id, i => i.InvoiceLines);
        
        foreach(var line in invoice.InvoiceLines) {
            this.DataContext.InvoiceLine.Remove(line);
        }
        
        this.DataContext.Invoices.Remove(invoice)
        this.DataContext.SaveChanges();
    }
