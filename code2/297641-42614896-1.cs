        List<ListViewItem> ITEMS = new List<ListViewItem>();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 20; i++)
            {
                ListViewItem OneItem = new ListViewItem();
                OneItem.Background = Brushes.LightGray;
                OneItem.Content = new Device() { IP = "1.1.1.1", Ping = "30ms", DNS = "XYZ", MAC = "2F:3C:5F:41:F9", Manufacturer = "Intel" };
                ITEMS.Add(OneItem);
                listView.ItemsSource = ITEMS;
            }
            listView.Items.Refresh();
        }
        public class Device
        {
            public string IP { get; set; }
            public string Ping { get; set; }
            public string DNS { get; set; }
            public string MAC { get; set; }
            public string Manufacturer { get; set; }
        }
