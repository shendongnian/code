    public class SampleConfigurations : IEntityTypeConfiguration<Sample>
    {
    public void Configure(EntityTypeBuilder<Sample> builder)
    {
        if (DB == "DB1")
            builder.Ignore(item => item.columnproperty);
    }
}
