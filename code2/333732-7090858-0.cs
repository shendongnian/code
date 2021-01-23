        void form_Loaded(object sender, RoutedEventArgs e)
        {
            XElement xml = XElement.Parse("file.xml");
            foreach (XElement el in xml.Elements())
            {
                ListBoxItem item = new ListBoxItem();
                string name = el.Attribute("name").Value;
                string value = el.Attribute("value").Value;
                item.Content = name + ": " + value;
                ListBox.Items.Add(item);
            }
        }
