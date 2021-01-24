	public void DeleteAuction()
	{
		try
		{
			bool isSuccess = false;
			DataTable dt = new DataTable(); 
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
				conn.Open();
				SqlCommand command = new SqlCommand("UPDATE AuctionTbl2 SET deleted = 1 WHERE id = @Id", conn);
				command.Parameters.AddWithValue("@Id",Id);
				int rows = command.ExecuteNonQuery();
				if(rows>0)
				{
					MessageBox.Show("Deletion Successfull");
					dt = selectAuction();
					auctionDataGridView.DataSource = dt;
				}
				else
					MessageBox.Show("Deletion Unsuccessfull");
			}
		}
	}
	catch(Exception e)
	{
		MessageBox.Show(e.Message);
	}
	
	//method to update the dataGridView after deletion
	public DataTable selectAuction()
	{
		try
		{
			DataTable table = new DataTable(); 
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
			    conn.Open();
				String sql = "select * from AuctionTbl2";          
				SqlCommand cmd = new SqlCommand(sql, con);         
				SqlDataAdapter adaptor = new SqlDataAdapter(cmd);                                         
				adaptor.Fill(table);    
			}				
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);                 
		}
		finally
		{
			con.Close();                 
		}
		return table;
	}
