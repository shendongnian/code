    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opentrans.org/XMLSchema/1.0")]
    [System.Xml.Serialization.XmlElementAttribute("Order")]
    public class Order() {
                String Type
    
            }
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opentrans.org/XMLSchema/1.0")]
    [System.Xml.Serialization.XmlRootAttribute("OrderList", Namespace="http://www.opentrans.org/XMLSchema/1.0", IsNullable=false)]
    public class OrderList() {
              List<Orders> 
    
            }
