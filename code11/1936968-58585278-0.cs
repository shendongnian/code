    public class PatientRepository : IPatientRepository
    {
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> PatientDataArray = new List<Patient>();
    
            Connection conn = new Connection();
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(conn.getConnectionString());
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM measurement;";
                cmd.Prepare();
    
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32("id");
                    decimal bloodsugar = reader.GetDecimal("bloodsugar");
                    decimal bloodsugardesired = reader.GetDecimal("bloodsugardesired");
                    string description = reader.GetString("description");
                    DateTime time = reader.GetDateTime("time");
    
                    PatientDataArray.Add(new Patient(ID, bloodsugar, bloodsugardesired, description, time));
               }
           }
           finally
           {
               if (connection != null)
                   connection.Close();
           }
    
           return PatientDataArray;
    }
