        public class InvoicesDoc
        {
            [XmlElement(ElementName = "invoice")]
            public AadeBookInvoiceType[] invoice { get; set; }
        }
        [XmlRoot(ElementName = "invoice")]
        public class AadeBookInvoiceType
        {
            //add the rest of the invoice properties here
        }
