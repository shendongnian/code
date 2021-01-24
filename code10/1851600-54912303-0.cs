     // be my data, 4 x a, 3 x b, 1 x c, 2 x d, As a list for easier linQ
     var data = new[] { "a", "a", "c", "b", "a", "b", "b", "d", "d", "a" }.ToList();
     // group by our condition. Here it's the value so very simple
     var groupedData = data.GroupBy(o => o).ToList();
     // transform all groups into a custom List of List of List so they are grouped by 2 internally
     // each list level represent Grouping -> Groups of 2 (or 1) -> element
     var groupedDataBy2 = groupedData.Select(grp => grp.ToList().Partition(2)).ToList();
     // find the group with the maximum amount of groups or 2 (and 1)
     var maxCount = groupedDataBy2.Max(grp => grp.Count());
                       
     // will contain our final objects listed
     var finalObjects = new List<string>();
     // loop on the count we figured out and try add each group one by one
     for (int i = 0; i < maxCount; i++)
     {
         // try each group
         foreach (var group in groupedDataBy2)
         {
             // add the correct index to our final list only if the current group has enough to fill
             if (i < group.Count)
             {
                 // add the data to our final list
                 finalObjects.AddRange(group[i]);
             }
         }
     }
     // result here is : a,a,c,b,b,d,d,a,a,b
     var results = string.Join(",", finalObjects);
