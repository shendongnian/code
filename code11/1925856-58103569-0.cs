c#
public virtual DbSet<CountryRegionMapping> CountryRegionMappings { get; set; }
public virtual DbSet<Country> Countries { get; set; }
public virtual DbSet<Region> Regions { get; set; }
Then you can access them same as you access `Countries`, or `Regions`:
c#
ApplicationDbContext db = new ApplicationDbContext();
db.CountryRegionMappings//.SingleOrDefault, etc.
