      /// <summary>
      /// Method to create lists containing all combinations of an input list of items. This is 
      /// basically copied from code by user "jaolho" on this thread:
      /// http://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
      /// </summary>
      /// <typeparam name="T">type of the items on the input list</typeparam>
      /// <param name="inputList">list of items</param>
      /// <param name="includeEmpty">switch specifying if output should include an empty list</param>
      /// <returns>list of lists for all possible combinations of the input items</returns>
      public static List<List<T>> AllCombinations<T>(List<T> inputList, bool includeEmpty)
      {
         int nonEmptyCombinations = (int)Math.Pow(2, inputList.Count) - 1;
         List<List<T>> listOfLists = 
                           new List<List<T>>(nonEmptyCombinations + (includeEmpty ? 1 : 0));
         if (includeEmpty)
            listOfLists.Add(new List<T>());
         for (int i = 1; i <= nonEmptyCombinations; i++)
         {
            List<T> thisCombination = new List<T>(inputList.Count);
            for (int j = 0; j < inputList.Count; j++)
            {
               if ((i >> j & 1) == 1)
                  thisCombination.Add(inputList[j]);
            }
            listOfLists.Add(thisCombination);
         }
         return listOfLists;
      }
