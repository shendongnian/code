    public abstract AUsuaConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : AUsua
    {
        public virtual void Configure(EntityTypeBuilder<AUsua> builder)
        {
    	    builder.HasKey(au => au.CdEmprsModl)
                .HasName( "SYS_C008235" );
            // etc.
        }
    }
    public UsuaConfiguration : AUsuaConfiguration<Usua>
    {
        public override void Configure(EntityTypeBuilder<Usua> builder)
        {
            // configure base class properties
            base.Configure(builder);
            // configuration unique to `Usua` here
        }
    }
