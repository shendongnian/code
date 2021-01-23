    [Serializable]
    public struct InvoiceItem
    {
        public string Product {get; set;}
        public string PartNumber {get; set;}
    }
    public class Invoices : System.Web.Services.WebService
    {
        /*[DataMember] ** needed If working with data contracts */
        public List<InvoiceItem> InvoiceItems {get; set;}
    }
