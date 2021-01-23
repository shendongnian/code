    using System;
    using System.Xml;
    using System.Collections.Generic;
    
    public static class MyXmlParser
    {
    	///This method will loop through each node to get to the data we want.
    	public static List<string> GetItemsFromXmlByLoopingThroughEachNode(string Filename)
    	{
    		//Create a list to store all the items.
    		List<string> Items = new List<string>();
    		
    		//Load the document from a file.
    		XmlDocument doc = new XmlDocument();
    		doc.Load(Filename);
    		
    		//Loop through all the nodes in the document.
    		foreach(XmlNode RootNode in doc.ChildNodes)
    		{
    			if(RootNode.NodeType != XmlNodeType.XmlDeclaration)
    			{//If the node is not the declaration node parse it.
    			
    				//Loop through all the child nodes of <root>
    				foreach(XmlNode Node1Node in RootNode.ChildNodes)
    				{
    					//Read Attributes of <node1>
    					XmlAttributeCollection attributes = Node1Node.Attributes;
    					XmlAttribute Attribute1 = attributes["attribute1"];
    					//Attribute1.Value will give you the string contained in the attribute.
    					
    					//Loop through all child nodes of <node1>
    					foreach(XmlNode Node2Node in Node1Node.ChildNodes)
    					{
    						//Loop through all child nodes of <node2>
    						foreach(XmlNode Node3Node in Node2Node.ChildNodes)
    						{
    							//These nodes contain the data we want so lets add it to our List.
    							Items.Add(Node3Node.InnerText);
    						}
    					}
    				}			
    			}
    		}
    		//Return the List of items we found.
    		return Items;
    	}
    	
    	///This method will use GetElementsByTagName to go right to the data we want.
    	public static List<string> GetItemsFromXmlUsingTagNames(string Filename, string TagName)
    	{
    		//Create a list to store all the items.
    		List<string> Items = new List<string>();
    		
    		//Load the document from a file.
    		XmlDocument doc = new XmlDocument();
    		doc.Load(Filename);
    		
    		//Get all the <node3> nodes.
    		XmlNodeList Node3Nodes = doc.GetElementsByTagName(TagName);
    		//Loop through the node list to get the data we want.
    		foreach(XmlNode Node3Node in Node3Nodes)
    		{
    			//These nodes contain the data we want so lets add it to our List.
    			Items.Add(Node3Node.InnerText);
    		}
    		//Return the List of items we found.
    		return Items;		
    	}
    }
