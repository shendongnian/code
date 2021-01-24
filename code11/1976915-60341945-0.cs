            modelBuilder.Entity<Client>().HasMany(x => x.Machines).WithOne(x=>x.Client).HasForeignKey(x=>x.ClientID);
            modelBuilder.Entity<Client>().HasKey(x => x.ID);
            modelBuilder.Entity<Machine>().HasKey(x => new { x.ID, x.ClientID });
            modelBuilder.Entity<MachineBob>().HasOne(x => x.Machine).WithMany(x => x.MachineBobData).HasForeignKey(x => new { x.MachineID, x.ClientID}).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MachineMixer>().HasOne(x => x.Machine).WithMany(x => x.MachineMixerData).HasForeignKey(x => new { x.MachineID, x.ClientID }).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MachineBob>().HasKey(c => new { c.TimeStamp, c.ClientID, c.MachineID });
            modelBuilder.Entity<MachineMixer>().HasKey(x => new { x.TimeStamp, x.MachineID, x.ClientID });
