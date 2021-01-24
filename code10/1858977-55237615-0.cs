             var lists = new List<List<string>>();
            lists.Add(new List<string> { "a", "b", "c" });
            lists.Add(new List<string> { "a", "c" });
            lists.Add(new List<string> { "d", "e" });
            lists.Add(new List<string> { "e", "d" });
            lists.Add(new List<string> { "e", "a" }); // from my comment
            var results = new List<List<string>>();
            foreach (var list in lists)
            {
                // all items already in list, just continue
                if (results.Any(r => r.Count == r.Union(list).Count()))
                {
                    continue;
                }
                // get the lists, that contains at least one item of the current "list".
                var listsWithItemsOfList = results.Where(r => list.Any(x => r.Contains(x)));
                // if none, than add this totally
                if (!listsWithItemsOfList.Any())
                {
                    results.Add(new List<string>(list));
                }
                // if exactly, one, that add all the items, that were missing
                else if(listsWithItemsOfList.Count() == 1)
                {
                    var l = listsWithItemsOfList.Single();
                    l.AddRange(list.Except(l));
                }
                else
                {
                    // if multiple, that means, that all needed are currently spreaded over multiples, that have to be merged.
                    var newMergedList = listsWithItemsOfList.SelectMany(x => x).Distinct().ToList();
                    results.RemoveAll(x => listsWithItemsOfList.Contains(x));
                    results.Add(newMergedList);
                }
            }
