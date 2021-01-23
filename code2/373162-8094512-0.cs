    bool allSameSize = new[] { list1, list2, list3, list4, list5, list6 }
                             .Select(list => list.Count)
                             .Distinct()
                             .Take(2) // Optimization, not strictly necessary
                             .Count() == 1;
