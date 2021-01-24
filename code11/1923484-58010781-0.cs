c#
var result = SortedList.GroupBy(x => x.Snapshottime.Ticks / interval.Ticks) .OrderBy(x => x.Key);
var resultList = new List<DataHolder>();
foreach(var group in result)
{
    resultList.Add(group.First());
}
I hope this helps.
