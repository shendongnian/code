    public static class LinqExtensions
    {
        public static IQueryable<int> CalculateAmounts(this IQueryable<Order> order)
        {
            return from o in order select o.Order_Details.Sum(i => i.Quantity);
        }
    }
    
    var amounts = (from o in context.Orders select o).CalculateAmounts();
