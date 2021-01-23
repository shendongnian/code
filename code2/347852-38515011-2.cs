    using System.Linq;
     
    namespace TimestampComparers
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new OrdersContext())
                {
                    var stamp = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, };
     
                    var lt = context.OrderLines.FirstOrDefault(l => l.TimeStamp.IsLessThan(stamp));
                    var lte = context.OrderLines.FirstOrDefault(l => l.TimeStamp.IsLessThanOrEqualTo(stamp));
                    var gt = context.OrderLines.FirstOrDefault(l => l.TimeStamp.IsGreaterThan(stamp));
                    var gte = context.OrderLines.FirstOrDefault(l => l.TimeStamp.IsGreaterThanOrEqualTo(stamp));
     
                }
            }
        }
    }
