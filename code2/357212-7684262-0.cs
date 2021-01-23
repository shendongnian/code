    private Dictionary<string, string> attributes = new Dictionary<string, string>();    
    private void textBox1_LostFocus(object sender, RoutedEventArgs e)
    {
        if (listBox1.SelectedValue != null) 
        {
            ListBoxItem a = listBox1.SelectedValue as ListBoxItem;
            string name = a.Content.ToString();
            string value = textBox1.Text;
            if (!this.attributes.ContainsKey(name) || this.attributes[name] != value)
            {
                 this.attributes[name] = value;
                 this.UpdateXml();
            }            
        }
    }
    private void UpdateXml()
    {
        foreach(KeyValuePair<string,string> attribute in this.attributes)
        {
            writer.WriteStartElement("Attribute",textBox1.Text);
            if (attribute.Key != null)
            {
                writer.WriteAttributeString("Name", attribute.Key);
            }
            
            writer.WriteAttributeString("Value", attribute.Value);
            writer.WriteEndElement();
        }
        writer.Flush();
    }
