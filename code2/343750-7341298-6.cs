    [Serializable]
    [XmlRoot(ElementName = "sroot", Namespace = "urn:my-examples:shaping")]
    public class CustomerList : List<Customer>
    {
    }
    [Serializable]
    public class Customer
    {
        ...
    }
