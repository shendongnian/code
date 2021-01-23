    [XmlRoot("Customers")]
    public class Customers
    {
    	[XmlElement("Customer")]
    	public List<TCustomer> List = new List<TCustomer>();
    }
