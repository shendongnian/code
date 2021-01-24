<!-- -->
    public class FilterObject
    {
      public IQueryable<Items> ApplyTo(IQueryable<Items> items)
      {
        return items
          .Where(item => item.Property1.Contains(this.Property1))
          .Where(item => item.Other == this.OtherString)
           // more Where clauses ad nauseum; you get the idea
      }
    }
