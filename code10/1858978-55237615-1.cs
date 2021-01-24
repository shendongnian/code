             var lists = new List<List<string>>();
            lists.Add(new List<string> { "a", "b", "c" });
            lists.Add(new List<string> { "a", "c" });
            lists.Add(new List<string> { "d", "e" });
            lists.Add(new List<string> { "e", "d" });
            lists.Add(new List<string> { "e", "a" }); // from my comment
            var results = new List<List<string>>();
            foreach (var list in lists)
            {
                // That checks, if for this list, there is already a list, that contains all the items needed.
                if (results.Any(r => r.Count == r.Union(list).Count()))
                {
                    continue;
                }
                // get the lists, that contains at least one item of the current "list".
				// This is important, as depending on the amount of elements, there have to be specific further steps.
                var listsWithItemsOfList = results.Where(r => list.Any(x => r.Contains(x)));
                // if not item, then you just have to add the whole content, as non of the colors exist.
                if (!listsWithItemsOfList.Any())
                {
                    results.Add(new List<string>(list));
                }
                // if exactly, one, that add all the items, that were missing
				// (it might be, that nothing is added in case list.Except(l) is empty.
                else if(listsWithItemsOfList.Count() == 1)
                {
                    var listWithOneItem = listsWithItemsOfList.Single();
                    listWithOneItem.AddRange(list.Except(listWithOneItem));
                }
                else
                {
                    // if multiple elements, it's getting complicated.
					// It means, that all needed items are currently spreaded over multiple lists, that have now to be merged.
                    var newMergedList = listsWithItemsOfList.SelectMany(x => x).Distinct().ToList(); // merge all into one
                    results.RemoveAll(x => listsWithItemsOfList.Contains(x)); // remove those lists from results
                    results.Add(newMergedList); // just add one new list, containing all.
                }
            }
