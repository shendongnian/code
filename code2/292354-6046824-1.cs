    class HouseConfiguration : EntityTypeConfiguration<House>
    {
        public HouseConfiguration()
        {
            // many-to-many w/tasktypes
            this.HasMany(h => h.TaskTypes)
                .WithMany(tt => tt.Houses) 
                .Map(m =>
                    {
                        m.ToTable("HouseTaskTypes");
                        m.MapLeftKey("HouseId");
                        m.MapRightKey("TaskTypeId");
                    });
        }
    }
