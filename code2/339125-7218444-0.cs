    public class SaleStatusMap: EntityTypeConfiguration<SaleStatus>
    {
        public SaleStatusMap()
        {
            ToTable("SaleStatus");
            HasKey(ss => ss.IdSaleStatus);
            Map<SaleStatusBooked>(pk => pk.Requires("StatusType").HasValue(1));                
            Map<SaleStatusPaid>(pk => pk.Requires("StatusType").HasValue(2));         
        }
    }
