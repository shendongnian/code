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
    var occurence = new List<string>();
    for (int i = list.Count - 1; i >= 0; i--)
    {
        if (!occurence.Contains(list[i]))
        {
            occurence.Add(list[i]);
            uniquePositions.Add(++i);
        }
    }
    uniquePositions.Reverse();
    return uniquePositions;
}
You call it like this:
c#
var result = GetSingleListPositions(list);
Console.WriteLine(string.Join(' ', result));
As a result, I receive this:
6 9 10
Hope this helps,
Cheers
