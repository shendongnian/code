    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			EnsureFiles();
    			Console.WriteLine("Press espace to quit");
    			ConsoleKeyInfo key;
    			do
    			{
    				key = Console.ReadKey();
    				Append(key);
    			}
    			while (key.Key != ConsoleKey.Escape);
    
    			Console.ReadLine();
    		}
    
    		private static void Append(ConsoleKeyInfo key)
    		{
    			var keyEvent = new XElement("KeyEvent",
    				new XElement("Key", new XAttribute("key", key.Key.ToString())), 
    				new XElement("At", DateTime.Now.ToString())
    				);
    			File.AppendAllText("slave.xmlpart", keyEvent.ToString());
    		}
    
    		private static void EnsureFiles()
    		{
    			if (!File.Exists("slave.xmlpart"))
    			{
    				File.WriteAllText("slave.xmlpart", ""); // simply create the file
    			}
    			if (!File.Exists("master.xml"))
    			{
    				var doc = new XDocument(
    					new XElement("WayPoints",
    						new XElement("{http://www.w3.org/2001/XInclude}include",
    							new XAttribute("href", "slave.xmlpart")
    							)
    					)
    				);
    				doc.Save("master.xml");
    			}
    		}
    	}
    }
