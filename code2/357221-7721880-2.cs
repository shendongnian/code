    private void textBox1_LostFocus(object sender, RoutedEventArgs e){
        if (listBox2.SelectedValue != null){
             string name = listBox2.SelectedItem.ToString();
             string value = textBox1.Text;
             if(!attributes_dict.ContainsKey(name)){
                 //attributes.Add(name, value);
                 attributes_dict[name] = value;
                 //UpdateXml();
             }else{
                 attributes_dict.Remove(name);
                 attributes_dict.Add(name, value);
                 //UpdateXml();
             }
         }
    }
    private  void button1_Click(object sender, RoutedEventArgs e){
         foreach (KeyValuePair<string, string> attribute in this.attributes_dict){
              writer.WriteStartElement("Attribute", textBox1.Text);
              if(attribute.Key != null){
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
