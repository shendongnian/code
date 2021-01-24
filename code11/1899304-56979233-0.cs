    public Npgsql.NpgsqlConnection DatabaseOpen()
    {
    	var sConnectionString = "Server=192.168.1.100;Port=5432;Username=postgres;Password=xxx;Database=analoginput;Pooling=false;MinPoolSize=1;MaxPoolSize=999;Timeout=15;";
    
    	var Conn = new Npgsql.NpgsqlConnection(sConnectionString);
    
    	Conn.Open();
    
    	return Conn;
    }
    public void Main()
    {
    	try
    	{
    		using (var conn = DatabaseOpen())
    		{
    			using (var InsertCommand = conn.CreateCommand())
    			{
    				InsertCommand.CommandText = "Select * From public.sensorlog WHERE \"date\" > '2019.07.08.' And \"date\" < '2019.07.10.' order by Date asc;";
    				System.Windows.MessageBox.Show(InsertCommand.CommandText);
    				Npgsql.NpgsqlDataReader reader = InsertCommand.ExecuteReader();
    				System.Data.DataTable CSV = new System.Data.DataTable();
    				while (reader.Read())
    				{
    					CSV.Load(reader);
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		System.Windows.MessageBox.Show(ex.Message);
    		
    	}
    	finally
    	{
    		Npgsql.NpgsqlConnection.ClearAllPools();
    	}
    }
