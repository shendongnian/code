    public class OrderedItem
    {
    	[XmlElementAttribute(Namespace = "http://www.cpandl.com")]
    	public string ItemName { get; set; }
    	[XmlElementAttribute(Namespace = "http://www.cpandl.com")]
    	public string Description { get; set; }
    	[XmlElementAttribute(Namespace = "http://www.cohowinery.com")]
    	public decimal UnitPrice { get; set; }
    	[XmlElementAttribute(Namespace = "http://www.cpandl.com")]
    	public int Quantity { get; set; }
    	[XmlElementAttribute(Namespace = "http://www.cohowinery.com")]
    	public int LineTotal { get; set; }
    }
