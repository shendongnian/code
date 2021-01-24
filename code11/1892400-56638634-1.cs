    public Class YourClass
    {
        private int? lastId;
        private const string MESSAGE_QUERY = "SELECT * FROM send_eMessages ORDER BY id DESC LIMIT 1";
    	private const string DATA_FILE_PATH = "somefilename.ext";
    
        private void AnteSala_Load(object sender, EventArgs e)
        {
    		this.lastId = ReadLastSeenId();
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
    
                    if(currentId != this.lastId)
                    {
                        this.lastId = currentId;
                        var eMessage = (reader.GetString("eMessage"));
    
                        /*...Your Popup Code...*/
    					
    					WriteLastSeenId(this.lastId);
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
    	
    	private static void WriteLastSeenId(int? id)
    	{
    		string rawValue = (id != null ? id.Value.ToString() : string.Empty);
    		
    		File.WriteAllText(DATA_FILE_PATH, rawValue);
    	}
    	
    	private static int? ReadLastSeenId()
    	{
    		int? id = null;
    		
    		if(File.Exists(DATA_FILE_PATH))
    		{
    			string rawValue = File.ReadAllText(DATA_FILE_PATH);
    			
    			if (int.TryParse(inputString, out int temp))
    			{
    				id = temp;
    			}
    		}
    		
    		return id;
    	}
    }
