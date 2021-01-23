     private void save_Click(object sender, RoutedEventArgs e)
     {
         foreach (CheckBox item in list1.Items)
         {
             if (item.IsChecked==true)
             {
                 MessageBox.Show(item.Content.ToString());
             }
         }
     }
