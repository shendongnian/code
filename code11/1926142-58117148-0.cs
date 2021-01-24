    public class Node
    {
        [Key]
        public Guid Id { get; set; }
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    
        public Route StartRoute { get; set; }
        public Route EndRoute { get; set; }
    }
    modelBuilder.Entity<Route>()
            .HasOne(x => x.StartNode)
            .WithOne(x => x.StartRoute)
            .HasForeignKey<Route>(x => x.StartNodeId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Route>()
            .HasOne(x => x.EndNode)
            .WithOne(x => x.EndRoute)
            .HasForeignKey<Route>(x => x.EndNodeId)
            .OnDelete(DeleteBehavior.Restrict);
