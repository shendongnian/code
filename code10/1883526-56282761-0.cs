    [Serializable]
    [XmlRoot(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2",
        ElementName = "Invoice",
        DataType = "string",
        IsNullable = true)]
    public class Invoice
    {
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CustomizationID { get; set; }
        // ...
    }
