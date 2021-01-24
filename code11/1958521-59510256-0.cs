    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace EFCoreShop
    {
        class ShopContext:DbContext
        {
    
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbQuery<BookInfo> BookInfos { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=**********;Database=EFCoreShop;User ID=*********;Password=***********");
            }
    
    
        }
    }
