     private void dgTable1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
     {
     string[] daten = new string[3];
     if (dgTable1.SelectedItem != null)
     {
     DataRowView datarow = (DataRowView)dgTable1.SelectedItem;
     daten[0] = (string)datarow.Row.ItemArray[0];
     daten[1] = (string)datarow.Row.ItemArray[1];
     daten[2] = (string)datarow.Row.ItemArray[2];                            
     }
     else
     MessageBox.Show("please select again");
     }
