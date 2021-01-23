    public class NerdDinners : DbContext
    {
        public NerdDinners(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
        public DbSet<Dinner> Dinners { get; set; }
    }
