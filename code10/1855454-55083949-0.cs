    public class SqlCommands
    {
        private readonly string _connectionString;
        public SqlCommands(string connectionString)
        {
            _connectionString = connectionString;
        }
     
        public void InsertUpdateContact(InsertUpdateContactParameters parameters)
        {
            using (SqlConnection sqlCon = new SqlConnection(_connectionString)) 
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ContactAddorEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PhoneBookID", parameters.PhoneBookId); //connecting each value to database
                sqlCmd.Parameters.AddWithValue("@FirstName",parameters.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName",parameters.LastName);
                sqlCmd.Parameters.AddWithValue("@Contact",parameters.Contact);
                sqlCmd.Parameters.AddWithValue("@Email", parameters.Email);
                sqlCmd.Parameters.AddWithValue("@Address",parameters.Address);
                sqlCmd.ExecuteNonQuery();
            }
        }
    }
    public class InsertUpdateContactParameters
    {
        public int PhoneBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
