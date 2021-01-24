c#
var totals = names.GroupBy(x => x)
    .Select(group => new { Name = group.Key, Count = group.Count() });
foreach ( var total in totals )
{
    Console.WriteLine($"{total.Name} | {total.Count} times");
}
Another option would be to use your existing code and just print out the values of the dictionary
var totals = names
    .Select(s => new { Key = s.Key, Count = s.Count()})
    .ToDictionary(d => d.Key, d => d.Count);
foreach ( var kvp in totals )
{
    Console.WriteLine($"{kvp.Key} | {kvp.Value} times");
}
