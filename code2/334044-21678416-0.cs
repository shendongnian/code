    class Model 
    {
        private SqlCommand loadUserCommand;
        private DataTable userData;
        public void LoadUser(string userId) 
        {
            loadUserCommand = GetUserLoadCommandForUserID(userId);
            userData = new DataTable("userData");
            using (var adapter = new SqlDataAdapter(loadUserCommand)) 
            {
                adapter.Fill(userData);
            }
        }
        public void AbortLoadUser()
        {
            if (loadUserCommand!= null)
                loadUserCommand.Cancel();
        }
    
        private SqlCommand GetUserLoadCommandForUserID(string userId)
        {
            var connection = new SqlConnection("...");
            var command = connection.CreateCommand();
            ...
        }
    }
