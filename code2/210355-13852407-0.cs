    public static bool ExportListViewlToXML(ListView listview, String filePath, String fileName)
        {
            FileStream fileStream;
            StreamWriter streamWriter;
            XmlTextWriter xmlTextWriter;
            try
            {
                // overwrite even if it already exists
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                streamWriter = new StreamWriter(fileStream);
                xmlTextWriter = new XmlTextWriter(streamWriter);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("Items");
                const int SUBITEM1_POS = 0;
                const int SUBITEM2_POS = 1;
                const int SUBITEM3_POS = 2;
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    String currentSubItem1 = listview.Items[i].SubItems[SUBITEM1_POS].Text;
                    String currentSubItem2 = listview.Items[i].SubItems[SUBITEM2_POS].Text;
                    String currentSubItem3 = listview.Items[i].SubItems[SUBITEM3_POS].Text;
                    xmlTextWriter.WriteStartElement("Item");
                    xmlTextWriter.WriteAttributeString("subitem1", currentSubItem1.ToString());
                    xmlTextWriter.WriteAttributeString("subitem2", currentSubItem2.ToString());
                    xmlTextWriter.WriteAttributeString("subitem3", currentSubItem3.ToString());
                    xmlTextWriter.WriteEndElement();
                }
                xmlTextWriter.WriteEndDocument();
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
                return true;
            }
            catch (IOException ex)
            {
                // do something about your error
                return false;
            }
        }
