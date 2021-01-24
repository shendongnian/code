    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    
    namespace ConsoleApp22
    {
        // The same models as in the example
        public class FinishedGoods
        {
            [Key]
            public int Id { get; set; }
    
            [NotMapped]
            public List<PartImageLink> PartImageLinks { get; set; } 
        }
    
        public class oePart
        {
            [Key]
            public int Id { get; set; }
        }
    
        public class PartImageLink
        {
            [Key]
            public int Id { get; set; }
    
            public int PartId { get; set; }
        }
    
        class AppDbContext : DbContext
        {
            public DbSet<FinishedGoods> FinishedGoods { get; set; }
            public DbSet<oePart> oeParts { get; set; }
            public DbSet<PartImageLink> PartImageLinks { get; set; }
    
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }
    
            public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries().ToList())
                {
                    if (entry.Entity.GetType() == typeof(FinishedGoods))
                    {
                        var finishedGoods = (FinishedGoods)entry.Entity;
    
                        if (finishedGoods.PartImageLinks != null)
                        {
                            foreach (var finishedGoodsPartLinks in finishedGoods.PartImageLinks)
                            {
                                Entry(finishedGoodsPartLinks).State = EntityState.Added;
                            }
                        }
                    }
                }
    
                return base.SaveChanges();
            }
        }
    
        // Custom models to wrap query objects
        class PartImageLinkWithFinishedGoods
        {
            public FinishedGoods FinishedGoods { get; set; }
    
            public PartImageLink PartImageLink { get; set; }
        }
    
        class PartImageLinkWithoePart
        {
            public oePart oePart { get; set; }
    
            public PartImageLink PartImageLink { get; set; }
        }
    
        class Program
        {
            // Seed data
            private static void AddSomeData(AppDbContext db)
            {
    
                db.FinishedGoods.Add(new FinishedGoods()
                {
                    Id = 1,
                });
    
                db.oeParts.Add(new oePart()
                {
                    Id = 2,
                });
    
                db.PartImageLinks.Add(new PartImageLink()
                {
                    Id = 1,
                    PartId = 1,
                });
    
                db.PartImageLinks.Add(new PartImageLink()
                {
                    Id = 2,
                    PartId = 2,
                });
    
                db.FinishedGoods.Add(new FinishedGoods()
                {
                    Id = 3,
                    PartImageLinks = new List<PartImageLink>()
                    {
                        new PartImageLink()
                        {
                            Id = 4,
                            PartId = 3
                        }
                    }
                });
    
                db.SaveChanges();
            }
    
            // Query your main table and join whatever you expect on PartId field
            static IQueryable<PartImageLinkWithFinishedGoods> GetImageLinkWithFinishedGoods(AppDbContext db, int id)
            {
                return db.PartImageLinks.Where(x => x.Id == id)
                    .Join(db.FinishedGoods,
                        x => x.PartId,
                        x => x.Id,
                        (x, y) => new PartImageLinkWithFinishedGoods() { PartImageLink = x, FinishedGoods = y });
    
            }
    
            static IQueryable<PartImageLinkWithoePart> GetImageLinkWithoeParts(AppDbContext db, int id)
            {
                return db.PartImageLinks.Where(x => x.Id == id)
                    .Join(db.oeParts,
                        x => x.PartId,
                        x => x.Id,
                        (x, y) => new PartImageLinkWithoePart() { PartImageLink = x, oePart = y });
    
            }
    
            static void Main(string[] args)
            {
                var options = new DbContextOptionsBuilder().UseInMemoryDatabase("db").Options;
                var db = new AppDbContext(options);
    
                AddSomeData(db);
    
                var itemWithFinishedGoods = GetImageLinkWithFinishedGoods(db, 4).FirstOrDefault();
                var itemWithoePart = GetImageLinkWithoeParts(db, 2).FirstOrDefault();
            }
    
        }
    }
