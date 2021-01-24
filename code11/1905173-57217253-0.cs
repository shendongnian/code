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
