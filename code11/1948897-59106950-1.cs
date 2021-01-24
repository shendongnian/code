    using System.Data.Entity;
    
    namespace CmsShop.Models.Data
    {
        public class DB:DbContext
        {
            public DbSet<PageDTO> Pages { get; set; }
        }
    }
