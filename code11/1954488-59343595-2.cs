     public IEnumerable<string> MyFilter(IEnumerable<string> source)
     {
          var temp = new Dictionary<string, bool>();
          foreach(var item in source)
          {
               var parent = SemiExpensiveCallToGetParent(item);
               if (temp.TryGetValue(parent, out bool result))
               {
                   if (result)
                        yield return item;
               }
               var matched = ExpensiveCallToCheckMatch(parent);
               temp.Add(parent, matched);
               if (matched)
                   yield return item;
          }
      }
