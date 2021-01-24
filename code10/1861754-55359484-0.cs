    namespace personalFinance
    {
        public partial class HomepageUC : UserControl
        {
           string login = "";
           public HomepageUC(string email)
              {
    
                InitializeComponent();
                login = email;
                var conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                AttachDbFileName=|DataDirectory|database.mdf;");
                conn.Open();
                var cmd = new SqlCommand($"SELECT email FROM registration_data 
                WHERE email = '{login}'", conn);
                var reader = cmd.ExecuteReader();
    			
                while (reader.Read())
    			{
    				if(!string.IsNullOrEmpty(reader[0].ToString()))
    				{
    					labelWelcome.Text = reader[0].ToString();
    					break;
    				}
    			}			
    		}
        }
    }
