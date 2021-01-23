      /// <summary>
      /// Method to create lists containing possible combinations of an input list of items. This is 
      /// basically copied from code by user "jaolho" on this thread:
      /// http://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
      /// </summary>
      /// <typeparam name="T">type of the items on the input list</typeparam>
      /// <param name="inputList">list of items</param>
      /// <param name="minimumItems">minimum number of items wanted in the generated combinations, 
      ///                            if zero the empty combination is included,
      ///                            default is one</param>
      /// <returns>list of lists for possible combinations of the input items</returns>
      public static List<List<T>> ItemCombinations<T>(List<T> inputList, int minimumItems = 1)
      {
         int nonEmptyCombinations = (int)Math.Pow(2, inputList.Count) - 1;
         List<List<T>> listOfLists = new List<List<T>>(nonEmptyCombinations + 1);
         if (minimumItems == 0)  // Optimize default case
            listOfLists.Add(new List<T>());
         for (int i = 1; i <= nonEmptyCombinations; i++)
         {
            List<T> thisCombination = new List<T>(inputList.Count);
            for (int j = 0; j < inputList.Count; j++)
            {
               if ((i >> j & 1) == 1)
                  thisCombination.Add(inputList[j]);
            }
            if (thisCombination.Count >= minimumItems)
               listOfLists.Add(thisCombination);
         }
         return listOfLists;
      }
