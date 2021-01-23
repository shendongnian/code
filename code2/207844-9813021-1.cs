    public class CustomerInfoMap : EntityConfiguration<CustomerInfo>
    {
      public CustomerInfoMap()
      {
        .ToTable("vwCustomerInfo");
      }
    }
