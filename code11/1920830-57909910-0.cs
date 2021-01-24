    public class Destination
        {
            public int DestinationId { get; set; }
            public int PreviousDestinationId { get; set; }
            
            public virtual Destination Previous { get; set; }
            public virtual Destination Next{ get; set; }
        }
        
        public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
        {
            public void Configure(EntityTypeBuilder<Destination> builder)
            {
                builder
                    .HasOne(p => p.Previous)
                    .WithOne(p => p.Next)
                    .HasForeignKey(p => p.PreviousDestinationId)
                    .OnDelete(DeleteBehavior.Restrict);
    
            }
        }
