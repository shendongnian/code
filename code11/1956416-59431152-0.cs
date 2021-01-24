    public static class StatesSeed
    {
        public static IEnumerable<State> States = new State[]
        {
            new State { StateName = "New South Wales", StateShortName = "NSW" },
            // ...
        }
    }
    
    
    public static class SuburbsSeed
    {
        public static IEnumerable<Suburb> Suburbs = new Suburb[]
        {
            new Suburb { PostCode = "200", SuburbName = "Australian National University", StateId = stateID, Latitude = -35.2777, Longditude = 149.1189 },
            // ...
        }
    }
    
    public class StatesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>().HasData(Seeds.States);
    		// ...
        }
    }
    
    
    public class SuburbsDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Suburb>().HasData(Seeds.Suburbs);
    		// ...
        }
    }
