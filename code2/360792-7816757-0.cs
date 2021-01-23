        [TestMethod]
        public void TestMethod1()
        {
            MongoServer server = MongoServer.Create(ConfigurationManager.ConnectionStrings["MongoUnitTestConnStr"].ConnectionString);
            MongoDatabase test = server.GetDatabase("unit_test_db");
            int totalDocuments = 100000;
            var list = Enumerable.Range(0, totalDocuments).ToList();
            int count = 0;
            DateTime start, end;
            using (server.RequestStart(test))
            {
                MongoCollection coll = test.GetCollection("testCollection");
                start = DateTime.Now;
                Parallel.ForEach(list, i =>
                {
                
                    var query = new QueryDocument("_id", i);
                    coll.Update(query, Update.Set("value", 100),
                                 UpdateFlags.Upsert, SafeMode.False);
                
                    // Calling a count periodically (but sparsely) seems to do the trick.
                    if (i%10000 == 0)
                        count = coll.Count();
                });
                // Call count one last time to report in the test results.
                count = coll.Count();
                end = DateTime.Now;
            }
            
            Console.WriteLine(String.Format("Execution Time:{0}.  Expected No of docs: {2}, Actual No of docs {3}", (end-start).TotalSeconds, count, totalDocuments));
        }
