    private void tv_Selected(object sender, RoutedEventArgs e)
        {
            System.Xml.XmlElement xmlElement= (XmlElement)tv.SelectedItem;
            string mySelectedValue = xmlElement.Attributes[0].Value.ToString();
            MessageBox.Show(mySelectedValue , "SelectedTreeValue", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        </i>
