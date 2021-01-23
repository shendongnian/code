    using System;
    using System.Data.Entity;
    using System.Data.Entity.Database;
    using System.Linq;
    namespace EFCodeFirst
    {
        public class Polygon
        {
            public int ID { get; set; }
            public String Name { get; set; }
            public Double Perimiter { get; set; }
        }
        public class Circle
        {
            public int ID { get; set; }
            public String Name { get; set; }
            public Double Radius { get; set; }
        }
        public class ShapeDbContext : DbContext
        {
            public DbSet<Polygon> Polygons { get; set; }
            public DbSet<Circle> Circles { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                DbDatabase.SetInitializer(new CreateDatabaseIfNotExists<BookDbContext>());
                using(var context = new ShapeDbContext())
                {
                    // creating a new object
                    context.Polygons.Add(new Polygon { Name = "P1", Perimiter = 3 });
                    context.Polygons.Add(new Polygon { Name = "P2", Perimiter = 2 });
                    context.SaveChanges();
                }
                using(var context = new ShapeDbContext())
                {
                    // creating a new object
                    var polygons = context.Polygons.Where(o => o.Perimiter < 3);
                    Console.WriteLine(polygons.Count());
                }
            }
        }
    }
