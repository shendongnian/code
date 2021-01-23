    using System.Data.SqlServerCe;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var cn = new SqlCeConnection("Data Source=MyDB.sdf"))
                {
                    cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select * from MyTable where Field2 like '%AB%'";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Field1: {0}", reader[0]);
                            }
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
