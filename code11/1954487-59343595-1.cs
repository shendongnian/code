      public class Helper
      {
           private readonly Dictionary<string,bool> tmp = new Dictionary<string, bool>();
           public bool Condition(string item)
           {
               var parent = SemiExpensiveCallToGetParent(x);
               if (temp.TryGetValue(parent, out bool result))
                  return result;
               var matched = ExpensiveCallToCheckMatch(parent);
               temp.Add(parent, matched);
               return matched;
           }
        }
