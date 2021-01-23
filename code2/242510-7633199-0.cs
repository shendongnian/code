    public class Dinner
    {
        public int DinnerId { get; set; }
        public string Title { get; set; }
    }
    
    public class NerdDinners : DbContext
    {
        public NerdDinners(string connString)
            : base(connString)
        {
        }
        public DbSet<Dinner> Dinners { get; set; }
    }
