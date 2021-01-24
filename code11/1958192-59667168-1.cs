    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using NetTopologySuite;
    using NetTopologySuite.Geometries;
    using ProjNet.CoordinateSystems;
    using ProjNet.CoordinateSystems.Transformations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace TestConsoleAppEFGeo
    {
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestApp;Trusted_Connection=True;MultipleActiveResultSets=true",
                    x => x.UseNetTopologySuite());
    
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
    
            public virtual DbSet<Facility> Facilities { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    
        public class Facility
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
    
            public NetTopologySuite.Geometries.Point Location { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var applicationDbContextFactory = new ApplicationDbContextFactory();
                var db = applicationDbContextFactory.CreateDbContext(null);
    
                var x = 13.003725d;
                var y = 55.604870d;
                var srid = 4326;
    
                if (!db.Facilities.AnyAsync(x => x.Id == 1).Result)
                {
                    var testFacility = new Facility();
                    var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid);
                    var currentLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(x, y));
                    testFacility.Id = 1;
                    testFacility.Location = currentLocation;
    
                    var testFacility2 = new Facility();
                    testFacility2.Id = 2;
                    testFacility2.Location = new Point(x, y) { SRID = srid };
                    db.Facilities.Add(testFacility);
                    db.Facilities.Add(testFacility2);
    
                    //Will throw an exception
                    //var testFacility3 = new Facility();
                    //testFacility3.Id = 3;
                    //testFacility3.Location = new Point(1447568.0454157612d, 7480155.2276327936d) { SRID = 3857 };
                    //db.Facilities.Add(testFacility3);
    
                    db.SaveChanges();
                }
    
                var facility1 = db.Facilities.FirstAsync(x => x.Id == 1).Result;
                var facility2 = db.Facilities.FirstAsync(x => x.Id == 2).Result;
    
                if(facility1.Location == facility2.Location)
                {
                    Console.WriteLine("facility1.Location is equal to facility2.Location");
                }
                else
                {
                    Console.WriteLine("facility1.Location is NOT equal to facility2.Location");
                }
    
                //Test conversion
                //Show coordinate: http://epsg.io/map#srs=4326&x=13.003725&y=55.604870&z=14&layer=streets
                //Conversion: http://epsg.io/transform#s_srs=4326&t_srs=3857&x=13.0037250&y=55.6048700
                //Google Maps - https://www.google.se/maps shows EPSG:4326 when viewing a location
                //https://epsg.io/3857 - Google Maps API is EPSG:3857 however
                //Example: https://developers.google.com/maps/documentation/javascript/markers
    
                var epsg3857ProjectedCoordinateSystem = ProjectedCoordinateSystem.WebMercator;
                var epsg4326GeographicCoordinateSystem = GeographicCoordinateSystem.WGS84;
    
                var coordinateTransformationFactory = new CoordinateTransformationFactory();
                var coordinateTransformation = coordinateTransformationFactory.CreateFromCoordinateSystems(epsg4326GeographicCoordinateSystem, epsg3857ProjectedCoordinateSystem);
    
                var epsg4326Coordinate = new GeoAPI.Geometries.Coordinate(facility1.Location.Coordinate.X, facility1.Location.Coordinate.Y);
    
                var epsg3857Coordinate = coordinateTransformation.MathTransform.Transform(epsg4326Coordinate);
    
            }
        }
    }
