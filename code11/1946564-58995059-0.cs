csharp
public List<int> DivisibleBy5Sorted(IEnumerable<int> a)
{
    var count = new int[251]; //count[i] will be the count of 5*i elements in original array
    foreach (var i in a)
    {
        //We are not interested in numbers not divideble by 5
        if (i % 5 != 0)
            continue;
        count[i / 5]++;
    }
    var result = new List<int>();
    //Go through all elements in ascending order
    for (var i = 0; i <= 250; i++)
    {
        //Add 5*i element the number of times it appears in array
        for (var j = 0; j < count[i]; j++)
            result.Add(i * 5);
    }
    return result;
}
