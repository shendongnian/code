    private void button1_Click(object sender, RoutedEventArgs e)  
    {  
       Collection.Add(new TempObject() { Name = "new item" });  
       comboBox1.SelectedIndex = -1;  
       ComboBoxItem item = comboBox1.ItemContainerGenerator.ContainerFromIndex(0) as ComboBoxItem;
       if (item != null) item.BringIntoView();
    }  
