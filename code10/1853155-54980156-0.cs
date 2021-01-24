         class Program
      {
        static void Main(string[] args)
        {
          // Initializing your list of strings
          List<string> list = new List<string>()
          {
            "M9", "M2", "M7", "M11", "M5", "M6", "M3", "M8", "M1", "M10", "M4", "M12"
          };
    
          SortStringList(list);
        }
    
        private static void SortStringList(List<string> list)
        {
          // Bubble sort
          bool change = true;
    
          while (change)
          {
            change = false;
            for (int i = 0; i < list.Count; i++)
            {
              if (i + 1 < list.Count)
              {
                // here im converting the string to a number removing the first char "M"
                int currentElement = Convert.ToInt32(list[i].Remove(0, 1));
                int nextElement = Convert.ToInt32(list[i + 1].Remove(0, 1));
                // comparing two integers and swapping the strings elements
                if (currentElement > nextElement)
                {
                  string tmp = list[i];
                  list[i] = list[i + 1];
                  list[i + 1] = tmp;
                  change = true;
                }
              }
            }
          }
        }
      }
