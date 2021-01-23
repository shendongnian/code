    public class InvoiceItems : List<InvoiceItem> {
        public InvoiceItems() { }
    
        // Copy constructor
        public InvoiceItems(IEnumerable<InvoiceItems> other) : base(other) { }
    }
    // …
    InvoiceItems distinctItems = new InvoiceItems(aBunchOfInvoiceItems.Distinct());
