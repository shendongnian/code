    public class JobConfig : IEntityTypeConfiguration<Job>
        {
            public void Configure(EntityTypeBuilder<Job> builder)
            {
                builder.HasOne(s => s.Client)
                .WithMany(g => g.Jobs)
                .HasForeignKey(f => f.ClientId);
    
                builder.HasOne(s => s.WarrantyCompany)
                    .WithMany(g => g.WarrantyCompanyJobs)
                    .HasForeignKey(f => f.WarrantyCompanyId);
            }
        }
