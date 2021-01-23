    private void CompareXml(string file1, string file2)
    {
        // Load the documents
        XmlDocument docXml1 = new XmlDocument();
        docXml1.Load(file1);
        XmlDocument docXml2 = new XmlDocument();
        docXml2.Load(file2);
        
        // Get a list of all player nodes
        XmlNodeList nodes1 = docXml1.SelectNodes("/Stats/Player");
        XmlNodeList nodes2 = docXml2.SelectNodes("/Stats/Player");
        // Define a single node
        XmlNode node1;
        XmlNode node2;
        // Get the root Xml element
        XmlElement root1 = docXml1.DocumentElement;
        XmlElement root2 = docXml2.DocumentElement;
        // Get a list of all player names
        XmlNodeList nameList1 = root1.GetElementsByTagName("Name");
        XmlNodeList nameList2 = root2.GetElementsByTagName("Name");
        // Get a list of all teams
        XmlNodeList teamList1 = root1.GetElementsByTagName("Team");
        XmlNodeList teamList2 = root2.GetElementsByTagName("Team");
        // Create an XmlWriterSettings object with the correct options. 
        XmlWriter writer = null;
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("  ");
        settings.OmitXmlDeclaration = false;
        // Create the XmlWriter object and write some content.
        writer = XmlWriter.Create(StatsFile.XmlDiffFilename, settings);
        writer.WriteStartElement("StatsDiff");
        // The compare algorithm
        bool match = false;
        int j = 0;
        try 
        {
            // the list has 500 players
            for (int i = 0; i < 500; i++)
            {
                while (j < 500 && match == false)
                {
                    // There is a match if the player name and team are the same in both lists
                    if (nameList1.Item(i).InnerText == nameList2.Item(j).InnerText)
                    {
                        if (teamList1.Item(i).InnerText == teamList2.Item(j).InnerText)
                        {
                            match = true;
                            node1 = nodes1.Item(i);
                            node2 = nodes2.Item(j);
                            // Call to the calculator and Xml writer
                            this.CalculateDifferential(node1, node2, writer);
                            j = 0;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
                match = false;
            
            }
            // end Xml document
            writer.WriteEndElement();
            writer.Flush();
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }
    }
