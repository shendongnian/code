    private void Chk_All_Checked(object sender, RoutedEventArgs e)
    {
      sqliteCon.Open();
      if (sqliteCon.State == System.Data.ConnectionState.Open)
      {
        if (chk_All.IsChecked == true) { 
        string q = @"UPDATE tabList
                         SET selection = 1";
        SqlCommand cmd = new SqlCommand(q, sqliteCon);
        cmd.ExecuteNonQuery();
        MessageBox.Show("All Items Checked");
        }
        
      }
      sqliteCon.Close();
    }
    
      private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
      sqliteCon.Open();
      if (sqliteCon.State == System.Data.ConnectionState.Open)
      {
        if (chk_All.IsChecked == false)
        {
          string q2 = @"UPDATE tabList
                         SET selection = 0";
          SqlCommand cmd2 = new SqlCommand(q2, sqliteCon);
          cmd2.ExecuteNonQuery();
          MessageBox.Show("All Items DeChecked");
        }
      }
      sqliteCon.Close();
    }
