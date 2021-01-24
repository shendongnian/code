    public static async Task PerformDatabaseOperations()
    {
        using (var ne = new NORTHWNDEntities())
        {
            try
            {
                var t = await ne.Products.AverageAsync(p => p.UnitPrice);
                Console.WriteLine($"Average unit price is {t}");
    
                var ao = await ne.Orders.GroupBy(o => o.OrderDate).AverageAsync(group => (double)group.Count());
                Console.WriteLine($"Average orders per day is {ao}");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.ToString());
            }       
        }
    }
