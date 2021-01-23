    private void button2_Click(object sender, EventArgs e)
    {
        List<BrokerInfo> listOfBroker = new List<BrokerInfo>()
        {
    	new BrokerInfo { Section = "TestSec1", Lineitem ="TestLi1" },
    	new BrokerInfo { Section = "TestSec2", Lineitem = "TestLi2" },
    	new BrokerInfo { Section = "TestSec3", Lineitem ="TestLi3" }
        };
    
        var xDoc = new XDocument(new XElement("Engagements",
    	    new XElement("BrokerData",
         from broker in listOfBroker
    
         select new XElement("BrokerInfo",
           new XElement("Section", broker.Section),
           new XElement("When", broker.Lineitem))
        )));
    
        xDoc.Save("D:\\BrokerInfo.xml");
    }
    
    public class BrokerInfo
    {
    	public string Section { get; set; }
    	public string Lineitem { get; set; }
    }
