    public sealed class ProductDiscountFilterCriteria : IFilterCriteria<string>
    {
      public decimal Discount { get; private set; }
    
      public string ToQuery()
      {
        // simplified
        return "WHERE Discount < " + this.Discount;
      }
    }
