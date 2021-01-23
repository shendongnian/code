    using System;
    using HtmlAgilityPack;
    using System.Xml;
    
    namespace HockeyStats
    {
        class StatsParser
        {
            private string htmlCode;
            private static string fileName = "[" + DateTime.Now.ToShortDateString() + " NHL Stats].xml";
    
            public StatsParser(string htmlCode)
            {
                this.htmlCode = htmlCode;
    
                this.ParseHtml();
            }
    
            public void ParseHtml()
            {
                
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlCode);
                XmlWriter writer = null;
    
                try
                {
                    // Create an XmlWriterSettings object with the correct options. 
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("  ");
                    settings.OmitXmlDeclaration = false;
    
                    // Create the XmlWriter object and write some content.
                    writer = XmlWriter.Create(@"..\..\"+fileName, settings);
                    writer.WriteStartElement("Stats");
                    writer.WriteAttributeString("Date", DateTime.Now.ToShortDateString());
    
                    // Get all tables in the document
                    HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
    
                    // Iterate all rows in the first table
                    HtmlNodeCollection rows = tables[0].SelectNodes(".//tr");
                    for (int i = 0; i < rows.Count; ++i)
                    {
                        // Iterate all columns in this row
                        HtmlNodeCollection cols = rows[i].SelectNodes(".//td[@class='statBox']");
                        for (int j = 0; j < cols.Count; ++j)
                        {
                            // Get the value of the column and print it
                            string value = cols[j].InnerText.Trim();
                            if (value != "")
                            {
                                switch (j)
                                {
                                    case 0:
                                        {
                                            writer.WriteStartElement("Player");
                                            writer.WriteAttributeString("Rank", cols[j].InnerText.Trim()); break;
                                        }
                                    case 1: writer.WriteElementString("Name", cols[j].InnerText.Trim()); break;
                                    case 2: writer.WriteElementString("Team", cols[j].InnerText.Trim()); break;
                                    case 3: writer.WriteElementString("Pos", cols[j].InnerText.Trim()); break;
                                    case 4: writer.WriteElementString("GP", cols[j].InnerText.Trim()); break;
                                    case 5: writer.WriteElementString("G", cols[j].InnerText.Trim()); break;
                                    case 6: writer.WriteElementString("A", cols[j].InnerText.Trim()); break;
                                    case 7: writer.WriteElementString("PlusMinus", cols[j].InnerText.Trim()); break;
                                    case 8: writer.WriteElementString("PIM", cols[j].InnerText); break;
                                    case 9: writer.WriteElementString("PP", cols[j].InnerText); break;
                                    case 10: writer.WriteElementString("SH", cols[j].InnerText); break;
                                    case 11: writer.WriteElementString("GW", cols[j].InnerText); break;
                                    case 12: writer.WriteElementString("OT", cols[j].InnerText); break;
                                    case 13: writer.WriteElementString("Shots", cols[j].InnerText); break;
                                    case 14: writer.WriteElementString("ShotPctg", cols[j].InnerText); break;
                                    case 15: writer.WriteElementString("TOIPerGame", cols[j].InnerText); break;
                                    case 16: writer.WriteElementString("ShiftsPerGame", cols[j].InnerText); break;
                                    case 17: writer.WriteElementString("FOWinPctg", cols[j].InnerText); break;
    
                                }
                            }
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.Flush();
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }
    }
