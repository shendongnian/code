    private void deleteButton_Click(object sender, RoutedEventArgs e)
       {
           try
           {
               DBConnDataContext db = new DBConnDataContext();
               tbWellClassification shortName = TableGrid.SelectedItem as tbWellClassification;
               var well = (from s in db.tbWellClassifications
                           where s.shortName == shortName.shortName
                           select s).Single();
               db.tbWellClassifications.DeleteOnSubmit(well);
               db.SubmitChanges();
               MessageBox.Show("Row Deleted Successfully.");
               txtStatus.Text = "Row Deleted";
               db = null;
               DBConnDataContext db2 = new DBConnDataContext();
               TableGrid.ItemsSource = db2.tbWellClassifications;
               TableGrid.Items.Refresh();
           }
           catch
           {
               MessageBox.Show("Delete Unsuccessful");
           }
          
       }
