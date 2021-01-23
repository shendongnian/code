            foreach (KeyValuePair<string, string> attribute in this.attributes_dict)
            {
                writer.WriteStartElement("Attribute", textBox1.Text);
                if (attribute.Key != null)
                {
                    writer.WriteAttributeString("Name1", attribute.Key);
                }
                writer.WriteAttributeString("Value1", attribute.Value);
                writer.WriteEndElement();
            }
            writer.Flush();
            writer.WriteEndElement();
            writer.Flush();
            writer.WriteEndDocument();
            writer.Close();
       }
