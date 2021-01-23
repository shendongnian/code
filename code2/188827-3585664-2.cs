    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    
    
    namespace EFTest
    {
        public class RequestBase
        {
            public int Id { get; set; }
            public DateTime? RequestedDate { get; set; }
            public int UserId { get; set; }
        }
    
        public class Mission
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public virtual ICollection<MissionRequest> MissionRequests { get; set; }
        }
    
        public class Column
        {
            public string Name { get; set; }
        }
    
        public class MissionRequest : RequestBase
        {
            public virtual Mission Mission { get; set; }
        }
    
        public class ShiftRequest : RequestBase
        {
            public Column Column { get; set; }
        }
    
        public class TestContext : DbContext
        {
            public DbSet<RequestBase> Requests { get; set; }
            public DbSet<Mission> Missions { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ContainerName = "EFTest";
                modelBuilder.IncludeMetadataInDatabase = false;
    
                // Example of complex type mapping. First you have to define 
                // complex type. Than you can access type properties in  
                // MapHiearchy.
                var columnType = modelBuilder.ComplexType<Column>();
                columnType.Property(c => c.Name).HasMaxLength(50);
    
                modelBuilder.Entity<Mission>()
                    .Property(m => m.Id)
                    .IsIdentity();
    
                modelBuilder.Entity<Mission>()
                    .HasKey(m => m.Id)
                    .MapSingleType(m => new { m.Id, m.Name })
                    .ToTable("dbo.Missions");
    
                modelBuilder.Entity<RequestBase>()
                    .Property(r => r.Id)
                    .IsIdentity();
    
                // You map multiple entities to single table. You have to  
                // add some discriminator to differ entity type in the table. 
                modelBuilder.Entity<RequestBase>()
                    .HasKey(r => r.Id)
                    .MapHierarchy()
                    .Case<RequestBase>(r => new { r.Id, r.RequestedDate, r.UserId, Discriminator = 0 })
                    .Case<MissionRequest>(m => new { MissionId = m.Mission.Id, Discriminator = 1 })
                    .Case<ShiftRequest>(s => new { ColumnName = s.Column.Name, Discriminator = 2 })
                    .ToTable("dbo.Requests");
            }
        }
    }
