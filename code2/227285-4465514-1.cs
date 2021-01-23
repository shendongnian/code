    public void executeNonQuery(string input)
    {
             db.Open();
             using (var txn = db.BeginTransaction())
             {
                 SqlCommand cmd = new SqlCommand(input, db);
                 cmd.Transaction = txn;
                 cmd.ExecuteNonQuery();
                 db.Close();
                 txn.Commit();
            }
    }
