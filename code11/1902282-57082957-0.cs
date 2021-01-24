        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            if (((ComboBoxItem)comboBox1.SelectedItem).Content.Equals("Choice1"))
                {
                listBox1.ItemsSource = null;
                listBox1.Items.Clear();
                listBox1.ItemsSource = File.ReadAllLines(@"C:\application1\serverlist1.txt");
                }
            return;
            }
