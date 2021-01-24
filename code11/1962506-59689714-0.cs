    using(OleDbConnection con = new OleDbConnection(.....))
    {
        OleDbCommand cmd = con.CreateCommand();
        con.Open();  
        Console.WriteLine("Connected...");
        cmd.CommandText = @"Insert into New1 ([B ID], [Dat], [Sum]) 
             SELECT BID, Dat, Summe 
             FROM Bestellung 
             Where [Datum] BETWEEN @d1 AND @d2";
        Console.WriteLine(DateTime.Today.AddDays(0));
        Console.WriteLine(DateTime.Today.AddDays(1));
        cmd.Parameters("@d1", OleDbType.Date).Value = DateTime.Today;
        cmd.Parameters("@d2", OleDbType.Date).Value = DateTime.Today.AddDays(1);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record Submitted");
    }
