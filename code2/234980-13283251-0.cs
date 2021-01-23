            XmlDocument doc = new XmlDocument();
            doc.Load("d:\\test.xml");
            XmlNodeList node = doc.GetElementsByTagName("w:r");
            foreach (XmlNode xn in node)
            {
                try
                {
                    if (xn["w:t"].InnerText != null)
                    {
                        if (xn["w:t"].InnerText == "#")
                        {
                            string placeHolder = xn["w:t"].InnerText;
                            foreach (XmlNode a in node)
                            { 
                                if (a["w:t"].InnerText != "#")
                                {
                                    string placeHolder1 = a["w:t"].InnerText;
                                }
                            } 
                        }
                    }
                }
                
                catch (Exception e)
                {
                    Console.Write(e);
                }
            } 
