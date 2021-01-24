    public class Calculator<T>
    {
       public decimal Average(List<T> items, Func<T, decimal> getValue)
       {
            decimal sum = 0;
    
            foreach (var item in items)
                sum += getValue(item);
    
            return sum / items.Count();
       }
    }
