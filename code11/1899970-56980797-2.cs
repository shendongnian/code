    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackoverFlow
    {
        class Program
        {
            private static FakeDatabaseContext _context = new FakeDatabaseContext();
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
                    .GroupJoin(_context.ServiceIntervals,
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
                public DbSet<ServiceInterval> ServiceIntervals { get; set; }
    
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer(
                        @"Server=(localdb)\mssqllocaldb;Database=Stackoverflow;Integrated Security=True");
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
                        _context.ServiceIntervals.Add(new ServiceInterval { Id = ((maxVehicles * i) + o).ToString(), VehicleId = i.ToString() });
                    }
                };
    
                _context.SaveChanges();
            }
    
            private static void CleanContext()
            {
                _context.Vehicles.RemoveRange(_context.Vehicles.ToArray());
                _context.ServiceIntervals.RemoveRange(_context.ServiceIntervals.ToArray());
                _context.SaveChanges();
            }
            #endregion Seed methods
        }
    }
