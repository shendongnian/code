    public class YourModelCustomizer : ModelCustomizer
        {
            public override void Customize(ModelBuilder modelBuilder, DbContext dbContext)
            {
                base.Customize(modelBuilder, dbContext);
                var entityTypeBuilderCart = modelBuilder.Entity<Models.Cart>()
                    .ToTable("ABC");
                entityTypeBuilderCart.Property(a => a.UserId).HasColumnName("XYZ");
                entityTypeBuilderCart.Property(a => a.ContractorId).HasColumnName("DFG");
                entityTypeBuilderCart.Ignore(a => a.CompanyId);
                var entityTypeBuilderCartArticle = modelBuilder.Entity<Models.CartArticle>()
                    .ToTable("IJK");
                entityTypeBuilderCartArticle.Property(a => a.UserId).HasColumnName("QWE");
            }
            public YourModelCustomizer(ModelCustomizerDependencies dependencies) : base(dependencies)
            {
            }
        }
