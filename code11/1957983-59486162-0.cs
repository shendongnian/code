    namespace Cascading_DropDownList_Entity_MVC
    {
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        
        public partial class Cascading_ddlEntities : DbContext
        {
            public Cascading_ddlEntities()
                : base("name=Cascading_ddlEntities")
            {
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
        
            public DbSet<City> Cities { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<State> States { get; set; }
        }
    }
