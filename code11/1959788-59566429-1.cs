    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace EfCore3Test
    {
    
    
        public class Author
        {
            public int AuthorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ICollection<Book> Books { get; } = new HashSet<Book>();
        }
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
        }
    
        public class Db : DbContext
        {
    
    
            public DbSet<Author> Authors { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
    
                modelBuilder.Entity<Book>()
                    .HasOne<Author>()
                    .WithMany(a => a.Books)
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.SetNull);
    
                base.OnModelCreating(modelBuilder);
            }
            public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EFCore3Test;Integrated Security = true", a => a.UseRelationalNulls(true))
                              .ConfigureWarnings(c => c.Log((RelationalEventId.CommandExecuting, LogLevel.Information)))
                              .UseLoggerFactory(MyLoggerFactory);
                base.OnConfiguring(optionsBuilder);
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new Db())
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    var a = new Author();
                    for (int i = 0; i < 10; i++)
                    {
    
                        var b = new Book();
                        a.Books.Add(b);
                    }
    
                    db.Authors.Add(a);
                    db.SaveChanges();
                }
    
    
    
    
               
                using (var db = new Db())
                {
                    var a = db.Authors.First();
                    db.Authors.Remove(a);
                    db.SaveChanges();
    
                }
            }
        }
    }
