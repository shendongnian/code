    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.IO;
    
    namespace XElementMadness
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var xml = "<session-factory xmlns=\"urn:nhibernate-configuration-2.2\"><property name=\"connection.release_mode\">on_close</property><property name=\"show_sql\">true</property></session-factory>";
    
    			var cfgDoc = XElement.Load(new StringReader(xml));
    			XNamespace ns = "urn:nhibernate-configuration-2.2";
    			var properties = cfgDoc.Elements(ns + "property");
    			
    			foreach (var x in cfgDoc.Elements(ns + "property"))
    			{
    				Console.WriteLine(x);
    			}
    
    			Console.ReadLine();
    		}
    	}
    }
