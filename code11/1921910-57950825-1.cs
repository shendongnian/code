    public class ClassBConfiguration : IEntityTypeConfiguration<ClassB>
    {
        public void Configure(EntityTypeBuilder<ClassB> builder)
        {
            builder.HasKey(b => new { b.Id, b.ClassAId });
            builder.HasOne(b => b.ClassA).WithMany(a => a.ClassBs).HasForeignKey(b => b.ClassAId);
        }
    }
