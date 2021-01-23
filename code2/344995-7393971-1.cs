    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    namespace EFIncludeTest
    {
        public class Parent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<ChildLevel1> ChildLevel1s { get; set; }
        }
        public class ChildLevel1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<ChildLevel2a> ChildLevel2as { get; set; }
            public ICollection<ChildLevel2b> ChildLevel2bs { get; set; }
        }
        public class ChildLevel2a
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ChildLevel2b
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Parent> Parents { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Create entities to test
                using (var ctx = new MyContext())
                {
                    var parent = new Parent
                    {
                        Name = "Parent",
                        ChildLevel1s = new List<ChildLevel1>
                        {
                            new ChildLevel1
                            {
                                Name = "FirstChildLevel1",
                                ChildLevel2as = new List<ChildLevel2a>
                                {
                                    new ChildLevel2a { Name = "FirstChildLevel2a" },
                                    new ChildLevel2a { Name = "SecondChildLevel2a" }
                                },
                                ChildLevel2bs = new List<ChildLevel2b>
                                {
                                    new ChildLevel2b { Name = "FirstChildLevel2b" },
                                    new ChildLevel2b { Name = "SecondChildLevel2b" }
                                }
                            },
                            new ChildLevel1
                            {
                                Name = "SecondChildLevel1",
                                ChildLevel2as = new List<ChildLevel2a>
                                {
                                    new ChildLevel2a { Name = "ThirdChildLevel2a" },
                                    new ChildLevel2a { Name = "ForthChildLevel2a" }
                                },
                                ChildLevel2bs = new List<ChildLevel2b>
                                {
                                    new ChildLevel2b { Name = "ThirdChildLevel2b" },
                                    new ChildLevel2b { Name = "ForthChildLevel2b" }
                                }
                            },
                        }
                    };
                    ctx.Parents.Add(parent);
                    ctx.SaveChanges();
                }
                // Retrieve in new context
                using (var ctx = new MyContext())
                {
                    var parents = ctx.Parents
                        .Include(p => p.ChildLevel1s.Select(c => c.ChildLevel2as))
                        .Include(p => p.ChildLevel1s.Select(c => c.ChildLevel2bs))
                        .Where(p => p.Name == "Parent")
                        .ToList();
                    // No exception occurs
                    // Check in debugger: all children are loaded
                    Console.ReadLine();
                }
            }
        }
    }
