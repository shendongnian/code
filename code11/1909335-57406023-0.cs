    public class FlatInvoiceItemModel
    {
        [Key]
        public int FlatInvoiceItemRid { get; set; }
        public int FlatInvoiceRid { get; set; }
        public string Particular { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }
        public AmendInvoice AmendInvoice { get; set; }
    }
    public class AmendInvoice
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FlatInvoiceItemModel> FlatInvoiceItemModels { get; set; }
    }
