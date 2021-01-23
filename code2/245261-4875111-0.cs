    [Serializable]
    [XmlRoot("customerList")]
    public class CustomerList 
    {
        [XmlArray("customers")]
        [XmlArrayItem("customer")]
        public List<TCustomer> Customers { get; set; }
    }
