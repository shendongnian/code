    using System.Data.Entity;
    
    namespace MvcApp.Models
    {
        public class MyAppContext : DBContext
        {
            public DBSet<Product> { get; set; }
        }
    }
