    static void Main(string[] args)
    		{
    			var xml = @"<root>
    								<parent a1 = 'foo' a2 = 'bar'>Some Parent text
    									<child a3 = 'frob' a2= 'brob'> Some Child Text
    									</child>
    								</parent>
    			</root>";
    			var file = new StringReader(xml) ;
    
    			using (XmlReader r = XmlReader.Create(file))
    			{
    				while (r.Read())
    				{
    					if (r.NodeType == XmlNodeType.Element)
    					{
    						if (r.Name == "parent")
    						{
    							var output = new StringBuilder();
    							var settings = new XmlWriterSettings();
    							settings.OmitXmlDeclaration = true;
    							using (var elementWriter = XmlWriter.Create(output, settings))
    							{	
    								
    								elementWriter.WriteStartElement(r.Name);
    								
    								elementWriter.WriteAttributes(r,false);
    								elementWriter.WriteValue(r.ReadString());
    								elementWriter.WriteEndElement();
    							}
    
    							Console.WriteLine(output.ToString());
    						}
    					}
    				}
    			}
    
    
    			if (System.Diagnostics.Debugger.IsAttached)
    				Console.ReadLine();
    
    		}
