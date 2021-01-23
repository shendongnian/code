    [XmlRoot(Namespace = CreateTextSearchResponse.CatalogNamespace)]
    public class CreateTextSearchResponse
    {
        public const string CatalogNamespace = "urn:veloconnect:catalog-1.1",
                    TransactionNamespace = "urn:veloconnect:transaction-1.0";
        [XmlElement(Namespace=TransactionNamespace)]
        public int BuyersId { get; set; }
        [XmlElement(Namespace = TransactionNamespace)]
        public int ResponseCode { get; set; }
        [XmlElement(Namespace = TransactionNamespace)]
        public int TransactionID { get; set; }
        [XmlElement(Namespace = TransactionNamespace)]
        public int StatusCode { get; set; }
        [XmlElement(Namespace = TransactionNamespace)]
        public bool IsTest { get; set; }
        [XmlElement(Namespace = CatalogNamespace)]
        public int TotalCount { get; set; }
    }
    public static void Main()
    {
        var ser = new XmlSerializer(typeof(CreateTextSearchResponse));
        var obj = new CreateTextSearchResponse
        {
            BuyersId = 12345,
            ResponseCode = 200,
            TransactionID = 225,
            StatusCode = 2,
            IsTest = false,
            TotalCount = 3876
        };
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("vcc", CreateTextSearchResponse.CatalogNamespace);
        ns.Add("vct", CreateTextSearchResponse.TransactionNamespace);
        ser.Serialize(Console.Out, obj, ns);
    }
