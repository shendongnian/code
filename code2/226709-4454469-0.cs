     private void ListBox1_DoubleClick(object sender, EventArgs e)
     {
         if (ListBox1.SelectedItem != null)
         {
             MessageBox.Show(ListBox1.SelectedItem.ToString());
         }
     }
