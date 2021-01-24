private List<DateTime[]> SplitMe(List<DateTime> bigList)
{
    var splitArrays = new List<DateTime[]>();
    var bigArray = bigList.ToArray();
    var previousItem = bigList[0];
    int lastEndingIndex = -1;
    for (int index = 1; index < bigArray.Length; index++)
    {
        var currentItem = bigArray[index];
        if (currentItem < previousItem + TimeSpan.FromSeconds(4))
        {
            var newArray = new DateTime[index - lastEndingIndex];
            Array.Copy(bigArray, lastEndingIndex + 1, newArray, 0, index - lastEndingIndex);
            splitArrays.Add(newArray);
            lastEndingIndex = index;
        }
        previousItem = currentItem;
    }
    return splitArrays;
}
If you do not like the array approach, you can use the much slower LINQ.
