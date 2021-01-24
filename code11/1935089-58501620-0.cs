c#
var list = new List<string>
{
    "A", // 1
    "A", // 2
    "A", // 3
    "B", // 4
    "B", // 5
    "A", // 6
    "B", // 7
    "B", // 8
    "C", // 9
    "B"  // 10
};
and then you call a method called `GetSingleListPositions` and receive `List<int>` representing your desired positions.
c#
private static List<int> GetSingleListPositions(IList<string> list)
{
    var uniquePositions = new List<int>();
    if (list.Count < 1)
    {
        return null;
    }
    var uniqueListElements = list.Distinct().ToList();
    var firstOccurence = new List<string>();
    foreach (var item in uniqueListElements)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == item && !firstOccurence.Contains(list[i]))
            {
                firstOccurence.Add(list[i]);
                uniquePositions.Add(i++);
            }
        }
    }
    return uniquePositions;
}
You call it like this:
c#
var result = GetSingleListPositions(list);
Console.WriteLine(string.Join(' ', result));
As a result, I receive this:
5 9 8
Hope this helps,
Cheers
