    using System;
    using Microsoft.EntityFrameworkCore;
    
    namespace InMemoryIdSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var options = new DbContextOptionsBuilder<CityContext>().UseInMemoryDatabase("Cities").Options;
                using (var context = new CityContext(options))
                {
                    context.Add(new City { Name = "Vienna" });
                    context.Add(new City { Name = "Munich" });
                    context.SaveChanges();
                }
                
                using (var context = new CityContext(options))
                {
                    foreach(var city in context.Cities)
                    {
                        Console.WriteLine($"City {city.Id}: {city.Name}");
                    }
                }
            }
        }
    
        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class CityContext : DbContext
        {
            public CityContext(DbContextOptions<CityContext> options) : base(options) { }
    
            public DbSet<City> Cities { get; set; }
        }
    }
