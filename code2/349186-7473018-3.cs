    interface IFilterCriteria<TQuery>
    {
       TQuery ToQuery();
    }
    
    public sealed class ProductDiscountFilterCriteria : IFilterCriteria<DynamicExpression>
    {
      public decimal Discount { get; private set; }
    
      public DynamicExpression ToQuery()
      {
        // build expression for LINQ clause Where("Discount" > this.Discount)
      }
    }
