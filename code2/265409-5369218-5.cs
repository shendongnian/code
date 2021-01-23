	internal abstract class AbstractMappingProvider<T> : IMappingProvider where T : class
	{
		public EntityTypeConfiguration<T> Map { get; private set; }
		public virtual void DefineModel( DbModelBuilder modelBuilder )
		{
			Map = modelBuilder.Entity<T>();
			Map.ToTable( typeof(T).Name );
		}
	}
