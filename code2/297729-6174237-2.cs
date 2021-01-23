               XmlDocument document = new XmlDocument();
            document.Load(@"D:/SavedPuzzle.xml");
            XmlNode topNode = document.GetElementsByTagName("MTiles")[0];
            foreach (XmlNode node in topNode.ChildNodes)
            {
                int X = Int32.Parse(node.ChildNodes[0].InnerText);
                int Y = Int32.Parse(node.ChildNodes[1].InnerText);
            }
