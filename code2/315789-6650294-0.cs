    public void CheckTimes()
        {
            
            MXFProgramme previousProg = null;
            MXFProgramme nextProg = null;
            using (XmlTextWriter writer = new XmlTextWriter("Gaps.xml",Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("tv");
                foreach (var prog in Programmes.OrderBy(p => p.channel))
                {
                    nextProg = prog;
                    if (previousProg != null)
                    {
                        if (previousProg.stopped != nextProg.started)
                        {
                            if (previousProg.channel == nextProg.channel)
                            {
                              
                                writer.WriteStartElement("programme");
                                writer.WriteAttributeString("channel", previousProg.channel);
                                writer.WriteAttributeString("channel2", previousProg.channel2);
                                writer.WriteAttributeString("start", string.Format("{0:yyyyMMddHHmmss} +0000", previousProg.stopped.ToLocalTime()));
                                writer.WriteAttributeString("stop", string.Format("{0:yyyyMMddHHmmss} +0000", nextProg.started.ToLocalTime()));
                                writer.WriteStartElement("title");
                                writer.WriteString("Channel Off Air");
                                writer.WriteEndElement();
                                writer.WriteStartElement("desc");
                                writer.WriteString("Programmes start again at" + " : " + nextProg.started.ToLocalTime().ToShortTimeString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("category");
                                writer.WriteString("General");
                                writer.WriteEndElement();
                                writer.WriteStartElement("length");
                                writer.WriteAttributeString("units", "minutes");
                                writer.WriteString(nextProg.started.Subtract(previousProg.stopped).TotalMinutes.ToString());
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }
                    }
                        previousProg = prog;
                    
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                StartMXF();
            }
  
        }
        public void StartMXF()
        {
            XmlDocument xXMLTVDoc = new XmlDocument();
            xXMLTVDoc.Load("Gaps.xml");
            XmlNodeList xNodes = xXMLTVDoc.SelectNodes("//tv");
            foreach (XmlNode xNode in xNodes)
            {
                foreach (XmlNode xN in xNode.ChildNodes)
                {
                    if (xN.Name == "programme")
                    {
                        MXFProgramme newProg = new MXFProgramme(xN);
                        Programmes.Add(newProg);
                        
                        foreach (MXFChannel Chn in Channels)
                        {
                            if (Chn.id == newProg.channel)
                                Chn.Programmes.Add(newProg); 
                        }
                        if (!SeriesList.Contains(newProg.Series))
                            SeriesList.Add(newProg.Series);
                       
                    }
                }
            }
            Programmes.Sort(new ArrayListSort());
            WriteMXF();
        }
