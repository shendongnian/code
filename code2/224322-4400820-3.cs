        static void Main(string[] args)
        {
        Console.WriteLine("Starting program execution...");
        string connectionString = @"Provider=VFPOLEDB.1;Data Source=h:\dave\"; 
     
        using (OleDbConnection connection = new OleDbConnection(connectionString)) 
        { 
            using (OleDbCommand scriptCommand = connection.CreateCommand()) 
            { 
                connection.Open();
                string vfpScript = @"SET EXCLUSIVE ON
                                    DELETE FROM sotest WHERE id = 5
                                    PACK"; 
     
                scriptCommand.CommandType = CommandType.StoredProcedure; 
                scriptCommand.CommandText = "ExecScript"; 
                scriptCommand.Parameters.Add("myScript", OleDbType.Char).Value = vfpScript; 
                scriptCommand.ExecuteNonQuery(); 
            } 
        } 
     
        Console.WriteLine("End program execution..."); 
        Console.WriteLine("Press any key to continue"); 
        Console.ReadLine(); 
        }
