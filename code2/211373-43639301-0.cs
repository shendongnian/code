    public class myDbModel:DbContext
    {
        public myDbModel(): base("name=ThingDb"){}
        public DbSet<Thing> Things { get; set; }  //db table
        public DbSet<ActiveThing> ActiveThings { get; set; } // now my ThingsController 'GetThings' pulls from this
    }
