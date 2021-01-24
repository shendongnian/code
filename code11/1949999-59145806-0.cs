    public class AUsuaConfiguration : IEntityTypeConfiguration<AUsua>
    {
        public void Configure(EntityTypeBuilder<AUsua> builder)
        {
    	    builder.HasKey(au => au.CdEmprsModl)
                .HasName( "SYS_C008235" );
            // etc.
        }
    }
