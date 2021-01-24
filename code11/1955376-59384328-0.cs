    while (reader.Read()) 
    {
        // Do some work here on the data.
    Console.WriteLine(reader.Name);
    }
    Console.ReadLine();
    while (reader.Read()) 
    {
        switch (reader.NodeType) 
        {
            case XmlNodeType.Element: // The node is an element.
                Console.Write("<" + reader.Name);
       Console.WriteLine(">");
                break;
      case XmlNodeType.Text: //Display the text in each element.
                Console.WriteLine (reader.Value);
                break;
      case XmlNodeType. EndElement: //Display the end of the element.
                Console.Write("</" + reader.Name);
       Console.WriteLine(">");
                break;
        }
    }
    while (reader.Read()) 
    {
           switch (reader.NodeType) 
           {
               case XmlNodeType.Element: // The node is an element.
                   Console.Write("<" + reader.Name);
    
                   while (reader.MoveToNextAttribute()) // Read the attributes.
                       Console.Write(" " + reader.Name + "='" + reader.Value + "'");
          Console.WriteLine(">");
                   break;
         case XmlNodeType.Text: //Display the text in each element.
                   Console.WriteLine (reader.Value);
                   break;
         case XmlNodeType. EndElement: //Display the end of the element.
                   Console.Write("</" + reader.Name);
          Console.WriteLine(">");
                   break;
           }
       }
