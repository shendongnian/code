    private async void Disp_data_Sim()
    {
    	var windowToOpen = new WaitingWorker()
    	{
    		Owner = this,
    	};
    
    		try
    		{
    			windowToOpen.ShowDialog();
    		
    			dataGridView1.DataSource = await GetDataAsync();
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show(ex.ToString());
    		}
    		
    		windowToOpen.Close();
    }
    
    private async Task<DataTable> GetDataAsync()
    {
    	var tempCon = File.ReadAllText("DBConnection.json");
    	var tempCon1 = Crypt.Decrypt(tempCon, "encryption");
    	var sqlInfo = new JavaScriptSerializer().Deserialize<SQLInfo>(tempCon1);
    	using (SqlConnection con = new SqlConnection(sqlInfo.GetConString()))
    	{
    		using (SqlCommand cmd = con.CreateCommand())
    		{
    			cmd.CommandText = "SELECT referencia,descricao,pr_custo1,etiqueta,qtd FROM Etiquetas Where etiqueta = @etiqueta";
    			cmd.Parameters.AddWithValue("@etiqueta", 'S');
    			using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    			{
    				DataTable dtbl = new DataTable();
    				await con.OpenAsync();
                    await Task.Yield(); // just to make sure it yields back to the caller.
    				da.Fill(dtbl);
    				return dtbl;
    			}
    		}
    	}
    }
