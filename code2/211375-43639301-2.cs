    public class myDbModel:DbContext
    {
        public myDbModel(): base("name=ThingDb"){}
        public DbSet<Thing> Things { get; set; }  //db table
        public DbSet<ActiveThing> ActiveThings { get; set; } // now my ThingsController 'GetThings' pulls from this
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //TPH (table-per-hierarchy):
          modelBuilder.Entity<Ross.Biz.ThingStatusLocation.Thing>()
            .Map<Ross.Biz.ThingStatusLocation.ActiveThing>(thg => thg.Requires("Discriminator").HasValue("A"))
            .Map<Ross.Biz.ThingStatusLocation.DeletedThing>(thg => thg.Requires("Discriminator").HasValue("D"));
        }
    }
