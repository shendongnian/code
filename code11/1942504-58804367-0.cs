    public class BaseLookupEntity<T> : BaseEntity where T : BaseLookupEntity<T>
    {
      [Key()]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public override int Id { get; set; }
      internal static void OnModelCreating(ModelBuilder modelBuilder)
      {
        // unique 
        modelBuilder.Entity<T>()
            .HasIndex(c => c.Enum)
            .IsUnique();
      }
    }
    public class UserType: BaseLookupEntity<UserType>
    {
    }
