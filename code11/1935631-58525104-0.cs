      public IEnumerable<int> GetMatch(List<string> items, string match)
      {
         string str = null;
         for (int i = 0; i < items.Count; i++)
         {
            if (!match.StartsWith(items[i]))
               continue;
            for (int j = 1; j < items.Count - i; j++)
            {
               str = items.Skip(i).Take(j).Aggregate((x, y) => x + y);
               if (str.Equals(match))
                  return Enumerable.Range(i + 1, j).Select(x => x).ToList();
               else if (match.StartsWith(str))
                  continue;
               break;
            }
         }
         return new int[0];
      }
      [Fact]
      public void Test()
      {
         var items = new List<string> { "1", ".", "249", "something", "1", ".", "250", "yes" };
         var match = "1.250";
         var matchingIndexes = GetMatch(items, match);
         Assert.True(matchingIndexes.Any());
         Assert.Equal(5, matchingIndexes.ElementAt(0));
         Assert.Equal(6, matchingIndexes.ElementAt(1));
         Assert.Equal(7, matchingIndexes.ElementAt(2));
      }
