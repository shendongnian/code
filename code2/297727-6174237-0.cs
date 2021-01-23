     XmlTextReader reader = new XmlTextReader("SavedPuzzle.xml");
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                XmlNode topNode = document.DocumentElement;
                foreach (XmlNode node in topNode.ChildNodes)
                {
                    int X = Int32.Parse(node.ChildNodes[0].Value);
                    int Y = Int32.Parse(node.ChildNodes[1].Value);
                }
