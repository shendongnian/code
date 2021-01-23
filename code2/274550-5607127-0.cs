    public class ProductInfo
    {
        public int IDX { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductManufacturerInfo> C0ProductManufacturers
        { get; set; }
    }
    public class ManufacturerInfo
    {
        public int IDX { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductManufacturerInfo> C0ProductManufacturers
        { get; set; }
    }
    public class ProductManufacturerInfo
    {
        public int IDX { get; set; }
        public bool Available { get; set; }
        public int ManufacturerRef { get; set; }        
        public virtual ManufacturerInfo C0Manufacturer { get; set; }
        public int ProductRef { get; set; }
        public virtual ProductInfo C0ProductInfo { get; set; }
    }
    public class ProductManufacturerConfiguration : EntityTypeConfiguration<ProductManufacturerInfo>
    {
        public ProductManufacturerConfiguration()  
        {  
            ToTable("ProductManufacturer");  
            HasKey(p => p.IDX);  
            Property(p => p.IDX).HasColumnName("pma_iIDX");  
            Property(p => p.Available).HasColumnName("pma_bAvailable");
            Property(p => p.ProductRef).HasColumnName("pma_iProductRef");
            Property(p => p.ManufacturerRef).HasColumnName("pma_iManufacturerRef");  
            //I have tried  
            HasRequired(p => p.C0Manufacturer)
                    .WithMany(c => c.C0ProductManufacturers)
                    .Map(m => m.MapKey("pma_iManufacturerRef"));
            HasRequired(p => p.C0ProductInfo)
                    .WithMany(c => c.C0ProductManufacturers)
                    .Map(m => m.MapKey("pma_iProductRef"));  
            //As well as  
            HasRequired(p => p.C0Manufacturer)
                    .WithMany(c => c.C0ProductManufacturers)
                    .HasForeignKey(p => p.ManufacturerRef);  
            HasRequired(p => p.C0ProductInfo)
                    .WithMany(c => c.C0ProductManufacturers)
                    .HasForeignKey(p => p.ProductRef);
        }
    }
