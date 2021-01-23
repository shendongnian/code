     private void ListBox1_MouseDoubleClick(object sender, RoutedEventArgs e)
     {
         if (ListBox1.SelectedItem != null)
         {
             MessageBox.Show(ListBox1.SelectedItem.ToString());
         }
     }
