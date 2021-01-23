     void SortLists(List<List<double>> lists)
     {
     int[] counter = new int[lists.Count];
     for (int i = 0; i < lists[0].Count; i++)
     {
         double MaxValue = double.MinValue;
         int winningList = 0;
         for (int j = 0; j < lists.Count; j++)
         {
            if(lists[j].ElementAt(i) > MaxValue )
            {
                MaxValue = lists[j].ElementAt(i);
                winningList = j;
            }
         }
         counter[winningList]++;
     }
     // sort the counter array, in effect your lists are sorted.
     }
