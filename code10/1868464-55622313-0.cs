    using (var conn = new SqlConnection("..."))
    {
        conn.Open();
        using (var sqlTxn = 
        conn.BeginTransaction(System.Data.IsolationLevel.Snapshot))
        {
            try
            {
                var sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.Transaction = sqlTxn;
                sqlCommand.CommandText =
                           @"UPDATE Blogs SET Rating = 5" +
                            " WHERE Name LIKE '%Entity Framework%'";
                sqlCommand.ExecuteNonQuery();
                using (var context =  
                    new BloggingContext(conn, contextOwnsConnection: false))
                {
                            context.Database.UseTransaction(sqlTxn);
                            var query =  context.Posts.Where(p => p.Blog.Rating >= 5);
                            foreach (var post in query)
                            {
                                post.Title += "[Cool Blog]";
                            }
                           context.SaveChanges();
                        }
                        sqlTxn.Commit();
            }
            catch (Exception)
            {
                 sqlTxn.Rollback();
            }
        }
    }
