    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Net;
    
    namespace LinqXMLTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Object[] res = { "Stackoverflow", true, 'x', 42};
    			XElement xml = new XElement("Foo",
    				from a in res select
    					new XElement("bar",
    						new XElement("type", a.GetType()),
    						new XElement("value", a.ToString())
    					)
    			);
    
    			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/test.php");
    			request.Method = "POST";
    			xml.Save( request.GetRequestStream() );
    			HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
    		}
    	}
    }
