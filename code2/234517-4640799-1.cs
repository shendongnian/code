       static void Main(string[] args)
        {
            SqlConnection cnnUserMan;
            SqlCommand cmmUser;
            //Instantiate and open the connection
            using (cnnUserMan = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\Program Files\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\MSSQL\\DATA\\UserDB.mdf; Integrated Security=True;Connect Timeout=30;User Instance=True"))
            {
                cnnUserMan.Open();
                //Instantiate and initialize command
                cmmUser = new SqlCommand("SelectID", cnnUserMan);
                cmmUser.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = cmmUser.ExecuteReader())
                {
                    // Loop through returned rows
                    while (dr.Read())
                    {
                        // Loop through all the returned columns
                        for (int col = 0; col < dr.FieldCount; col++)
                        {
                            Console.Write(dr.GetName(col) + " = " + dr.GetValue(col));
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }
