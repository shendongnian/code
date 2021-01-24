    using (DbContexts.MyDbContext db = new DbContexts.MyDbContext())
            {
                    using (var cmd = db.Database.Connection.CreateCommand())
                    {
                        db.Database.Connection.Open();
                        cmd.CommandText = "EXEC dbo.MyProc @param1=@param1";
                        cmd.Parameters.Add(new SqlParameter("@param1", SqlDbType.Int) { Value = 1 });
                        using (var rdr = cmd.ExecuteReader())
                        {
                            using (var objectContext = ((IObjectContextAdapter)db).ObjectContext)
                            {
                                List<string> listSTring = objectContext.Translate<string>(rdr).ToList();
                                rdr.NextResult();
                                List<MyClass> listMyClass = objectContext.Translate<MyClass>(rdr).ToList();
                            }
                        }
                    }
            }
