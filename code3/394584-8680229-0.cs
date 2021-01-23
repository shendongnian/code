    var sc1 = mssql.CreateCommand();
    var sc2 = mysql.CreateCommand();
    sc1.CommandText = sc2.CommandText = "select id, name, email, phone from yourtable ORDER BY Id";
    sc1.CommandTimeout = sc2.CommandTimeout = 0;
    
                using (var r1 = sc1.ExecuteReader())
                {
                    using (var r2 = sc2.ExecuteReader())
                    {
                        while (true)
                        {
                            bool read1 = r1.Read();
                            if (read1 ^ r2.Read())
                                throw new Exception("Doesn't match!");
                            
                            if(!read1) {Console.WriteLine("MATCH!!!"); break;}
    
                            for (int i = 0; i < r1.FieldCount; i++)
                            {
                                if (r1.IsDBNull(i) ^ r2.IsDBNull(i))
                                    throw new Exception("Doesn't match!");
    
                                if (string.Compare(r1[i].ToString(), r2[i].ToString(), StringComparison.InvariantCultureIgnoreCase) != 0)
                                    throw new Exception("Doesn't match!");
    
                            }
                        }
                    }
                }
