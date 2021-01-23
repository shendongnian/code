    OrderedItem example = new OrderedItem
    			{
    				ItemName = "Widget",
    				Description = "Regular Widget",
    				UnitPrice = (decimal) 2.3,
    				Quantity = 10,
    				LineTotal = 23
    			};
    
    XmlSerializer serializerX = new XmlSerializer(example.GetType());
    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
    namespaces.Add("inventory", "http://www.cpandl.com");
    namespaces.Add("money", "http://www.cohowinery.com");
    serializerX.Serialize(Console.Out, example, namespaces);
