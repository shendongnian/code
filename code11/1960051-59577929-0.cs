    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
    	if (typeof(TEntity).BaseType == null)
    		builder.ToTable(typeof(TEntity).Name, Schema);
    }
