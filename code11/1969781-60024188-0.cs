    public class DbContextBase : DbContext 
	{
        public override int SaveChanges() 
		{
			DateTime currentDateTime = DateTime.Now;
            // get all the entities in the change tracker - this could be optimized
            // to fetch only the entities with "State == added" if that's the only 
            // case you want to handle
			IEnumerable<DbEntityEntry<BaseEntity>> entities = ChangeTracker.Entries<BaseEntity>();
			// handle newly added entities
			foreach (DbEntityEntry<BaseEntity> entity in entities.Where(e => (e.State == EntityState.Added)) 
			{
                // set the CreatedOn field to the current date&time
				entity.Entity.CreatedOn = currentDateTime;
			}
			// to the actual saving of the data
			return base.SaveChanges();
        }
	}
