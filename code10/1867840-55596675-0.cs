	private void DeleteBtn_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			SqlConnection conn = new SqlConnection();
			conn.ConnectionString = 
			ConfigurationManager.ConnectionStrings["ConnString"].ToString();
			conn.Open();
			string query = "delete from AuctionTbl2";  // i think you are not aaully deleting the record you want to delete
			SqlCommand comm = new SqlCommand(query, conn);
			comm.ExecuteNonQuery();
			MessageBox.Show("Deleted");
			conn.Close();
			BindDataGrid();
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	 private void AddNew_Click(object sender, RoutedEventArgs e)
	{
		NewDeleteWindow newDeleteWindow = new NewDeleteWindow();
		newDeleteWindow.DataContext = new NewSaveButton();
		newDeleteWindow.ShowDialog();
		BindDataGrid();
	}
