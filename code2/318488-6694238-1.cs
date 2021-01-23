    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace DeserializeExample
    {
    	[Serializable]
    	[XmlRoot("root")]
    	public class BillingItems : List<BillingItem>
    	{
    		public static BillingItems GetBillingItems()
    		{
    			using (TextReader reader = new StreamReader("BillingItems.xml"))
    			{
    				XmlSerializer serializer = new XmlSerializer(typeof(BillingItemResult));
    				BillingItemResult billingItemResult = (BillingItemResult)serializer.Deserialize(reader);
    				return billingItemResult.Items;
    			}
    		}
    	}
    }
