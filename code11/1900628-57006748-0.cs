c#
List<int> list1 = new List<int> { 78, 92, 100, 37, 81 };
List<int> list2 = new List<int> { 3, 92, 1, 37 };
IEnumerable<int> result = list1
    .Concat(list2)              // Concat both lists to one big list. Don't use Union! It drops the duplicated values!
    .GroupBy(g => g)            // group them by values
    .Where(g => g.Count() == 1) // only values which have a count of 1
    .Select(s => s.Key);        // select the values
Console.WriteLine(string.Join(", ", result));
