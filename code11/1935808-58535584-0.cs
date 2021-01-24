    XmlTextReader myTextReader = new XmlTextReader(filename);
    myTextReader.WhitespaceHandling = WhitespaceHandling.None;
    while (myTextReader.Read())
    {
        if (myTextReader.NodeType == XmlNodeType.Element &&
            myTextReader.LocalName == "Reward" &&
            myTextReader.IsStartElement() == true)
            {
                ProcessRewardNode(myTextReader);
                    myTextReader.Skip();
        }
    }
