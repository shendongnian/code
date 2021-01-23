    static void Main(string[] args)
    {
        List<string> tablelist = new List<string>();
        if (!args[0].Contains(','))
            tablelist.Add(args[0]);
        else
            tablelist.AddRange(args[0].Split(','));
        string sqlconnectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        var connectionString = "mongodb://localhost/?safe=true;w=1;wtimeout=30s";
        var safemode = SafeMode.True;
        MongoServer server = MongoServer.Create(connectionString);
        MongoDatabase db = server.GetDatabase("testdb");
        MongoCollection<MongoDB.Bson.BsonDocument> coll = db.GetCollection<BsonDocument>("test");
        //coll.Find().Count();
        int i = 0;
        foreach (string table in tablelist)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                string query = "select * from " + table;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    /// Delete the MongoDb Collection first to proceed with data insertion
                    if (db.CollectionExists(table))
                    {
                        MongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>(table);
                        collection.Drop();
                    }
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BsonDocument> bsonlist = new List<BsonDocument>(1000);
                    while (reader.Read())
                    {
                        if (i == 1000)
                        {
                            using (server.RequestStart(db))
                            {
                                //MongoCollection<MongoDB.Bson.BsonDocument> 
                                coll = db.GetCollection<BsonDocument>(table);
                                coll.InsertBatch(bsonlist);
                                bsonlist.RemoveRange(0, bsonlist.Count);
                            }
                            i = 0;
                        }
                        ++i;
                        BsonDocument bson = new BsonDocument();
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            if (reader[j].GetType() == typeof(String))
                                bson.Add(new BsonElement(reader.GetName(j), reader[j].ToString()));
                            else if ((reader[j].GetType() == typeof(Int32)))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt32(j))));
                            }
                            else if (reader[j].GetType() == typeof(Int16))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt16(j))));
                            }
                            else if (reader[j].GetType() == typeof(Int64))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt64(j))));
                            }
                            else if (reader[j].GetType() == typeof(float))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetFloat(j))));
                            }
                            else if (reader[j].GetType() == typeof(Double))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetDouble(j))));
                            }
                            else if (reader[j].GetType() == typeof(DateTime))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetDateTime(j))));
                            }
                            else if (reader[j].GetType() == typeof(Guid))
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetGuid(j))));
                            else if (reader[j].GetType() == typeof(Boolean))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetBoolean(j))));
                            }
                            else if (reader[j].GetType() == typeof(DBNull))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonNull.Value));
                            }
                            else if (reader[j].GetType() == typeof(Byte))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetByte(j))));
                            }
                            else if (reader[j].GetType() == typeof(Byte[]))
                            {
                                bson.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader[j] as Byte[])));
                            }
                            else
                                throw new Exception();
                        }
                        bsonlist.Add(bson);
                    }
                    if (i > 0)
                    {
                        using (server.RequestStart(db))
                        {
                            //MongoCollection<MongoDB.Bson.BsonDocument> 
                            coll = db.GetCollection<BsonDocument>(table);
                            coll.InsertBatch(bsonlist);
                            bsonlist.RemoveRange(0, bsonlist.Count);
                        }
                        i = 0;
                    }
                }
            }
        }
    }
