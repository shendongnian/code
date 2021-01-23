    public class InvoiceItems : List<InvoiceItem>
    {
      public InvoiceItems(IEnumerable<InvoiceItem> items)
        base(items){}
    }
