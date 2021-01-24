        public static ModelBuilder FixOwnedAttributeImplementation(this ModelBuilder modelBuilder)
        {
            // loop over all entities
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // find properties that reference a type that is marked as [Owned]
                foreach (var property in entity.GetNavigations().Where(p => p.ClrType.GetCustomAttributes(typeof(OwnedAttribute), true).Any()))
                {
                    // enforce table sharing
                    modelBuilder.Entity(entity.Name).OwnsOne(property.ClrType, property.AsNavigation().Name).ToTable(entity.Relational().TableName);
                }
            }
            return modelBuilder;
        }
   
