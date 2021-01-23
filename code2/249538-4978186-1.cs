    string query = "SELECT SUM (Price) FROM Bill";
    using (System.Data.IDbCommand command = new System.Data.OleDb.OleDbCommand(query, DBconn))
    {
       object result = command.ExecuteScalar();
       TotalValueLabel.Text = Convert.ToString(result);
    }
