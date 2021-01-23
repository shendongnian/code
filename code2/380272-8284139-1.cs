        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"..."))
                {
                    conn.Open();
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    using (SqlTransaction trn = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand(
                           "insert into good (a) values (@i)", conn, trn);
                        SqlParameter p = new SqlParameter("@i", SqlDbType.Int);
                        cmd.Parameters.Add(p);
                        for (int i = 0; i < 10000; ++i)
                        {
                            p.Value = i;
                            cmd.ExecuteNonQuery();
                        }
                        trn.Commit();
                        sw.Stop();
                    }
                    Console.WriteLine("Good: {0}", sw.Elapsed);
                    int excount = 0;
                    sw.Reset();
                    sw.Start();
                    using (SqlTransaction trn = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand(
                            "insert into bad (a) values (@i)", conn, trn);
                        SqlParameter p = new SqlParameter("@i", SqlDbType.Int);
                        cmd.Parameters.Add(p);
                        for (int i = 0; i < 10000; ++i)
                        {
                            p.Value = i;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException s)
                            {
                                ++excount;
                            }
                        }
                        trn.Commit();
                        sw.Stop();
                    }
                    Console.WriteLine("Bad: {0} [Exceptions: {1}]",  
                       sw.Elapsed, excount);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
