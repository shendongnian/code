    public class Contract
    {
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public int RacingVehicleId { get; set; }
        public virtual RacingVehicle RacingVehicle { get; set; }
        public int SeasonsRemaining { get; set; }
    }
    public class RacingContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RacingVehicle> RacingVehicles { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasKey(contract => new { contract.DriverId, contract.RacingVehicleId });
        }
    }
