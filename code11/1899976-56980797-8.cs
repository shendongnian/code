    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackoverFlow
    {
        class Program
        {
            private static FakeDatabaseContext _context = new FakeDatabaseContext();
            private static FakeDatabaseContext2 _context2 = new FakeDatabaseContext2();
    
            static void Main(string[] args)
            {
                CleanContext();
                LoadContext();
    
                foreach (var vehicle in GetVehicles())
                {
                    Console.WriteLine(JsonConvert.SerializeObject(vehicle, Formatting.Indented));
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
    
            public static IQueryable<Vehicle> GetVehicles()
            {
                return _context.Vehicles
                    .Where(v => v.Schedule && !v.Suspend)
                    .GroupJoin(_context.ServiceIntervals(new DateTime(), new DateTime()),
                        v => v.Id,
                        si => si.VehicleId,
                        (v, si) => SetServiceIntervals(v, si));
            }
    
            private static Vehicle SetServiceIntervals(Vehicle v, IEnumerable<ServiceInterval> si)
            {
                v.RepairsToSchedule = si;
                return v;
            }
    
            #region EF Context
            public class FakeDatabaseContext : DbContext
            {
                public DbSet<Vehicle> Vehicles { get; set; }
                private DbSet<ServiceInterval> _serviceIntervals { get; set; }
    
                public IQueryable<ServiceInterval> ServiceIntervals(DateTime startingDate, DateTime endingDate)
                {
                    return _serviceIntervals.FromSql($@"
                        SELECT *
                        FROM Stackoverflow2.dbo.ServiceIntervals"
                    );
                }
    
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer(
                        @"Server=(localdb)\mssqllocaldb;Database=Stackoverflow;Integrated Security=True");
                    optionsBuilder
                        .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
                }
            }
    
            // Used to load a seperate database
            public class FakeDatabaseContext2 : DbContext
            {
                public DbSet<ServiceInterval> ServiceIntervals { get; set; }
    
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer(
                        @"Server=(localdb)\mssqllocaldb;Database=Stackoverflow2;Integrated Security=True");
                    optionsBuilder
                        .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
                }
            }
    
            public class Vehicle
            {
                public string Id { get; set; }
                public bool Schedule { get; set; }
                public bool Suspend { get; set; }
                public IEnumerable<ServiceInterval> RepairsToSchedule { get; set; }
            }
    
            public class ServiceInterval
            {
                public string Id { get; set; }
                public string VehicleId { get; set; }
            }
            #endregion EF Context
    
            #region Seed methods
            private static Random _random = new Random();
            private static bool _randomBool => _random.Next() % 2 == 1;
    
            private static void LoadContext()
            {
                var maxVehicles = 10;
                for (int i = 1; i < maxVehicles; i++)
                {
                    _context.Vehicles.Add(new Vehicle { Id = i.ToString(), Schedule = _randomBool, Suspend = _randomBool });
    
                    for (int o = 1; o < _random.Next(10); o++)
                    {
                        _context2.ServiceIntervals.Add(new ServiceInterval { Id = ((maxVehicles * i) + o).ToString(), VehicleId = i.ToString() });
                    }
                };
    
                _context.SaveChanges();
                _context2.SaveChanges();
            }
    
            private static void CleanContext()
            {
                _context.Vehicles.RemoveRange(_context.Vehicles.ToArray());
                _context2.ServiceIntervals.RemoveRange(_context2.ServiceIntervals.ToArray());
                _context.SaveChanges();
                _context2.SaveChanges();
            }
            #endregion Seed methods
        }
    }
