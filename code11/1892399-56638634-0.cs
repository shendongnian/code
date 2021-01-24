    public Class YourClass
    {
    	private int? lastId;
    	private const string MESSAGE_QUERY = "SELECT * FROM send_eMessages ORDER BY id DESC LIMIT 1";
    	
        private void AnteSala_Load(object sender, EventArgs e)
        {
             /*...Your Timer Code...*/
        }
    	private void ReadInformationFromeMessage()
    	{
    		try
    		{	
    			var myCommand = new MySqlCommand(MESSAGE_QUERY, ConexaoBancoMySql.GetConexao());
    			var reader = myCommand.ExecuteReader();
    			
    			if(reader.Read())
    			{
    				int currentId = reader.GetInt32("id");
    				
    				if(currentId != lastId)
    				{
    					lastId = currentId;
    					var eMessage = (reader.GetString("eMessage"));
    					
    					/*...Your Popup Code...*/
    				}
    			}
    		}
    		catch (MySqlException ex)
    		{
    			MessageBox.Show(ex.ToString());
    		}
    		finally
    		{
    			ConexaoBancoMySql.FecharConexao();
    		}
    	}
    }
