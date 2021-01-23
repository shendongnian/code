    using System;
    using System.Xml.Linq;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace X 
    { 
    	static class Y 
    	{
    		public static int Main(string[] args)
    		{
    			var data = new Record[] {
    				new Record(1, "n1", 1, null),
    					new Record(2, "n2", 1, null),
    					new Record(3, "n3", 1, 1),
    					new Record(4, "n4", 2, 2),
    					new Record(5, "n5", 2, 3),
    					new Record(6, "n6", 2, 4),
    			};
    
    			Func<Record, XElement> subtree;
    			subtree = node => new XElement("node", 
    					new XAttribute("name", node.NodeName),
    					new XAttribute("nodeID", node.NodeID),
    					new XAttribute("NodeAttribute1", node.NodeAttribute1),
    					data.ChildrenOf(node.NodeID).Select(subtree));
    
    			XElement xml = new XElement("NodeTree",
    					data.Where(root => root.NodeAttribute2 == null)
    					.Select(subtree));
    
    			Console.WriteLine(xml);
    			return 0;
    		}
    
    		struct Record
    		{
    			public readonly int NodeID;
    			public readonly string NodeName;
    			public readonly int  NodeAttribute1; //level?
    			public readonly int? NodeAttribute2; //parent
    
    			internal Record(int id, string name, int at1, int? at2) 
    			{
    				NodeID = id;
    				NodeName = name;
    				NodeAttribute1 = at1;
    				NodeAttribute2 = at2;
    			}
    		}
    
    		private static IEnumerable<Record> ChildrenOf(this IEnumerable<Record> data, int? parentId)
    		{
    			return data.Where(child => child.NodeAttribute2 == parentId);
    		}
    	}
    }
