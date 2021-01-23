        void form_Loaded(object sender, RoutedEventArgs e)
        {
            XElement xml = XElement.Parse(string.Join("", File.ReadAllLines("XMLFile1.xml")));
            foreach (XElement el in xml.Elements())
            {
                ListBoxItem item = new ListBoxItem();
                string name = el.Attribute("name").Value;
                string value = el.Attribute("Value").Value;
                item.Content = name + ": " + value;
                ListBox.Items.Add(item);
            }
        }
