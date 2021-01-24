     public class FooMapping : IEntityTypeConfiguration<Foo>
        {
            public void Configure(EntityTypeBuilder<Foo> builder)
            {
                builder.ToTable("FooTable");
                builder.Property(c => c.Id).HasColumnName("nameofyourcolumninsqltable").IsRequired();;
                builder.Property(c => c.Name).HasColumnName("nameofyourcolumninsqltable");;
                builder.Property(c => c.Phone).HasColumnName("nameofyourcolumninsqltable");
            }
        }
