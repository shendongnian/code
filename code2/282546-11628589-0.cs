                Response.Clear();
                Response.ContentType = "text/xml";
                Response.AppendHeader("Content-Disposition","attachment;filename=FileName.xml");
                XmlTextWriter xWriter = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);
                xWriter.Formatting = Formatting.Indented;
                xWriter.WriteStartDocument();
                //Create Parent element
                xWriter.WriteStartElement("Parent");
                //Create Child elements
                xWriter.WriteStartElement("Element");
                xWriter.WriteElementString("ID", "1001");
                xWriter.WriteElementString("Name", "John");
                xWriter.WriteElementString("Age", "22");
                xWriter.WriteEndElement();
                //End writing top element and XML document
                xWriter.WriteEndElement();
                xWriter.WriteEndDocument();
                xWriter.Close();
                Response.End();
            }
