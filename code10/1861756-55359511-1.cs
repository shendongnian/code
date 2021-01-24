    public partial class HomepageUC : UserControl
    {
       string login = "";
       public HomepageUC() // Default constructor for the designer/properties inicialization
       {
           InitializeComponent();
       }
       public HomepageUC(string email): this() // Your business logic constructor calls the default one
          {
            
            login = email;
            var conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
            AttachDbFileName=|DataDirectory|database.mdf;");
            conn.Open();
            var cmd = new SqlCommand($"SELECT email FROM registration_data WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email", email); // Use parameters to avoid SQLi 
            var reader = cmd.ExecuteReader();
            while (reader.Read()) labelWelcome.Text = reader[0].ToString();
            conn.Close(); // Added unmanaged resources liberation
            conn.Dispose();
          }
     }
 }
