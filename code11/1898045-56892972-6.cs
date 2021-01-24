        Dictionary<int, string> map = new Dictionary<int, string>();
        map.Add(256, "OI");
        map.Add(302, "OI");
        map.Add(303, "N2");
        map.Add(304, "N2.5");
        map.Add(400, "N2");
        var orderedMap = map.OrderBy(item => item.Key); // Order the map
        var minDiffGroup = orderedMap.SelectMany(item1 =>
             orderedMap
             .SkipWhile(item2 => !object.Equals(item1, item2)) //skip all elements which were already merged
             .Skip(1) //skip item1 == item2
             .Select(item2 => new { Diff = Math.Abs(item1.Key - item2.Key), Item1 = item1, Item2 = item2 }) //create an unknown type with Key = diff and both items
          )
          .GroupBy(item => item.Diff) //group by Diff
          .OrderBy(group => group.Key) //order by Diff
          .FirstOrDefault(); //Take the smallest group
        if (minDiffGroup?.Count() > 0)
        {
            var lowestChain = minDiffGroup
                 .OrderBy(item => item.Item1.Key) //order by the key of item1
                 .TakeWhile(item => item.Item1.Key + minDiffGroup.Key == item.Item2.Key) //take all items as long as the next item has the difference of this group (otherwise there is a gap)
                 .SelectMany(item => new List<KeyValuePair<int, string>>() { item.Item1, item.Item2 }) //select all collected KeyValuePairs
                 .Distinct(); //take every once
            foreach (var item in lowestChain)
            {
                Console.WriteLine(item);
            }
        }
