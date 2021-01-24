c#
    public static async Task PerformDatabaseOperations()
                {
                    using (var db = new BloggingContext())
                    {
                        // Create a new blog and save it
                        db.Blogs.Add(new Blog
                        {
                            Name = "Test Blog #" + (db.Blogs.Count() + 1)
                        });
                        Console.WriteLine("Calling SaveChanges.");
                        await db.SaveChangesAsync();
                        Console.WriteLine("SaveChanges completed.");
    
                        // Query for all blogs ordered by name
                        Console.WriteLine("Executing query.");
                        var blogs = await (from b in db.Blogs
                                    orderby b.Name
                                    select b).ToListAsync();
    
                        // Write all blogs out to Console
                        Console.WriteLine("Query completed with following results:");
                        foreach (var blog in blogs)
                        {
                            Console.WriteLine(" - " + blog.Name);
                        }
                    }
                }
