        public bool Return()
        {
            if (IsFree())
                return false;
            const string SQL = "UPDATE Borrow SET Return_date = @Date WHERE Book_ID = @Id AND Return_date IS NULL";
            using (OleDbConnection connection = new OleDbConnection(
               connectionString))
            {
                using(OleDbCommand command = new OleDbCommand(SQL)) {
                   command.Connection = connection;
                   command.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@Id", Id),
                        new OleDbParameter("@Date", DateTime.Now)
                    });
                   command.Connection.Open();
                   command.ExecuteNonQuery();
                }
            }
            return true;
        }
You should not close the connection yourself and it is better to use a new connection each time
