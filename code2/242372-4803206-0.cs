    // some codes here
    using (OleDbDataReader dr = dbCommand.ExecuteReader())
    { 
        while (dr.Read())
        {
            string f1 = dr.GetString("Field1");
            string f1 = dr.GetString("Field2");
            GView.Rows.Add(new object[] {f1, f2});
        }
    }
