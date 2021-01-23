	public class ProductManufacturerConfiguration 
        : EntityTypeConfiguration<ProductManufacturerInfo>
	{
		public ProductManufacturerConfiguration()
		{
			ToTable("ProductManufacturer");
			HasKey(p => new { p.C0ManufacturerIDX, p.C0ProductInfoIDX });
			Property(p => p.IDX)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
