    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> configuration)
        {
            configuration.OwnsOne(typeof(Address), "Address", buildAction => buildAction.HasForeignKey("AInvestmentId"));
        }
    }
