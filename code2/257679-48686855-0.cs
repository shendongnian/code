    XmlReaderSettings settings = new XmlReaderSettings();
    settings.DtdProcessing = DtdProcessing.Parse;
    XmlReader reader = XmlReader.Create("C:\\Temp\\items.xml", settings);
    String firstName = "", lastName = "", phone = "";
    String lastTagName = "";
    Boolean bItemFound = false;
    long nCounter = 0;
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    reader.MoveToContent();
    // Parse the file and display each of the nodes.
    while (reader.Read())
    {
        switch (reader.NodeType)
        {
            case XmlNodeType.Element:
                //Console.Write("<{0}>", reader.Name);
                lastTagName = reader.Name;
                if (lastTagName ==  "address")
                    nCounter++;
                break;
            case XmlNodeType.Text:
                //Console.Write(reader.Value);
                switch (lastTagName)
                {
                   case "firstName":
                        firstName = reader.Value.ToString();
                        bItemFound = firstName.Contains("97331");
                        break;
                    case "lastName":
                        lastName = reader.Value.ToString();
                        break;
                    case "phone":
                        phone = reader.Value.ToString();
                        break;
                }
                break;
            case XmlNodeType.CDATA:
                //Console.Write("<![CDATA[{0}]]>", reader.Value);
                break;
            case XmlNodeType.ProcessingInstruction:
                //Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                break;
            case XmlNodeType.Comment:
                //Console.Write("<!--{0}-->", reader.Value);
                break;
            case XmlNodeType.XmlDeclaration:
                //Console.Write("<?xml version='1.0'?>");
                break;
            case XmlNodeType.Document:
            case XmlNodeType.DocumentType:
                //Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                break;
            case XmlNodeType.EntityReference:
                //Console.Write(reader.Name);
                break;
            case XmlNodeType.EndElement:
                //Console.Write("</{0}>", reader.Name);
                break;
        }
        if (bItemFound)
        {
            Console.Write("{0}\n{1}\n{2}\n", firstName, lastName, phone);
            bItemFound = false;
        }
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("RunTime " + elapsedTime);
    Console.WriteLine("Searched items: {0}", nCounter);
    Console.ReadKey();
