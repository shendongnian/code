    XmlTextReader reader = new XmlTextReader("file.xml");
    while (reader.Read())
    {
    	reader.NodeType.Dump();
        switch (reader.NodeType)
        {
            case XmlNodeType.Element:
                Console.Write("<" + reader.Name);
                Console.WriteLine(">");
    			  while (reader.MoveToNextAttribute()) {
    			    Console.WriteLine(" {0}={1}", reader.Name, reader.Value);
    			  } 
    			  break;
            case XmlNodeType.Text:
                Console.WriteLine(reader.Value);
                break;
            case XmlNodeType.EndElement:
                Console.Write("</" + reader.Name);
                Console.WriteLine(">");
                break;
        }
    }
  [1]: https://stackoverflow.com/a/417020/2032864
