    using (SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TestDb;Data Source=.\\SQLEXPRESS;"))
    {
        conn.Open();
        Stopwatch watch = Stopwatch.StartNew();
        SqlCommand comm = new SqlCommand("INSERT INTO Users (UserName, [Password]) VALUES ('Simon', 'Password')", conn);
        for (int i = 0; i < 100000; i++)
        {
            comm.ExecuteNonQuery();
        }
        Console.WriteLine("SqlCommand: {0}", watch.Elapsed);
    }
