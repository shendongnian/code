    // It's late and I'm tired, the array declaration might be off.
    public static void Visit(this int[][] array, Action<int> visitor)
    {
          foreach (int[] columns in array)
          {
              foreach (int element in columns)
              {
                  visitor(element);
              }
          }
    }
    
    myArray.Visit(elem => Console.WriteLine(elem));
