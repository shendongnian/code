    static void Main(string[] args)
    {
        string path = @"..\..\TestFiles\Test_1.xml";
        if (File.Exists(path) == true)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.PreserveWhitespace = true;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                xDoc.Load(fs);
            }
    
            //Instantiate an XmlNamespaceManager object. 
            System.Xml.XmlNamespaceManager xmlnsManager = new System.Xml.XmlNamespaceManager(xDoc.NameTable);
    
            //Add the namespaces used to the XmlNamespaceManager.
            xmlnsManager.AddNamespace("x", "http://www.myApps.co.uk/");
    
            // Create a list of nodes to have the Canonical treatment
            XmlNodeList nodeList = xDoc.SelectNodes("/x:ApplicationsBatch/x:Applications|/x:ApplicationsBatch/x:Applications//*", xmlnsManager);
    
            //Initialise the stream to read the node list
            MemoryStream nodeStream = new MemoryStream();
            XmlWriter xw = XmlWriter.Create(nodeStream);
            nodeList[0].WriteTo(xw);
            xw.Flush();
            nodeStream.Position = 0;
    
            // Perform the C14N transform on the nodes in the stream
            XmlDsigC14NTransform transform = new XmlDsigC14NTransform();
            transform.LoadInput(nodeStream);
    
            // use a new memory stream for output of the transformed xml 
            // this could be done numerous ways if you don't wish to use a memory stream
            MemoryStream outputStream = (MemoryStream)transform.GetOutput(typeof(Stream));
            File.WriteAllBytes(@"..\..\TestFiles\CleanTest_1.xml", outputStream.ToArray());
        }
    }
