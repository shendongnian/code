c#
double[] numbers1 = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };
double[] numbers2 = { 2.2 };
IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
foreach (double number in onlyInFirstSet)
    Console.WriteLine(number);
This of course requires the definition of an `IEqualityComparer` for custom classes.
An alternative syntax using `where` would be:
c#
var antiJoin = numbers1.Where(number => !numbers2.Contains(number));
Read more on [Enumerable.Except Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.except) on Microsoft docs.
**Edit:**
As for "*db driven linq*" here is an example that will work for `Entity Framework` using `Except`:
C#
var filteredProducts = db.Products.ToList()
    .Except(db.Orders.Where(o => o.OrderId = 123)
        .Select(o => o.Product).ToList())
    .ToList();
as for the `where` alternative:
var filterProducts = db.Orders.Where(o => o.OrderId = 123)
    .Select(o => o.Product).ToList();
var antiJoinProducts = db.Products.Where(p => !filterProducts.Contains(p));
