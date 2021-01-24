     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
    
            modelBuilder.HasSequence<int>("BikePartIdHelper", schema: "dbo").StartsAt(1).IncrementsBy(1);
            
            modelBuilder.Entity<BikeParts>(entity =>
            {
                    entity.ToTable("BikeParts1");
                    entity.HasKey(e => e.ID);
                    entity.Property(e => e.ID).HasColumnName("ID").UseSqlServerIdentityColumn();
                    entity.Property(e => e.BikePartId).HasColumnName("BikePart_ID")
                    .HasDefaultValueSql("NEXT VALUE FOR dbo.BikePartIdHelper");
                    entity.Property(e => e.BikePartName)
                        .HasColumnName("BikePart_Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);
                    entity.Property(e => e.BikePartsGuid)
                        .HasColumnName("BikeParts_GUID")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasComputedColumnSql("('ABCD-'+right(replicate('0',(8))+CONVERT([varchar],[BikePart_ID]),(8)))");
            });        
     }
