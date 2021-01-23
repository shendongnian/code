    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet..."))
    using (OleDbCommand cmd = new OleDbCommand("ALTER TABLE MyTable ADD CONSTRAINT idxMyTable PRIMARY KEY (MyColumn)", cn))
    {
      cn.Open();
      cmd.ExecuteNonQuery();
    }
