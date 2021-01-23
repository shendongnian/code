 int saves = 0;
 List<Saves> saveGames = new List<Saves>();
                 while (textReader.Read())
                {
                    if (textReader.NodeType == XmlNodeType.Element)
                        whatsNext = textReader.Name;
                    else if (textReader.NodeType == XmlNodeType.Text)
                    {
                        if (whatsNext == "name")
                            saveGames[saves].name = Convert.ToString(textReader.Value);
                        //else if statements for the rest of your attributes
                        else if (whatsNext == "player")
                            saves++;
                    }
                    else if (textReader.NodeType == XmlNodeType.EndElement)
                        whatsNext = "";
                }
