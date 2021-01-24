       modelBuilder.Entity<Object>(o =>
        {
            o.HasData(new Object()
            {
                Id = 1,
                Name = "Test Object",
                //Building = testBuilding,
                BuildingId = 1 
            });
        });
