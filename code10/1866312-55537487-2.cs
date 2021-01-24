    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.AddressFrom).WithMany().HasForeignKey(o => o.AddressFromId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.AddressTo).WithMany().HasForeignKey(o => o.AddressTo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
