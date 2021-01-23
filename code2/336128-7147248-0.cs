    public static IEnumerable<int> Range(this IEnumerable<int> enumerable, Func<int> start, int size)
        {
           int rangeMiddle = start();
           foreach(int item in enumerable)
           {
              if(item >= (rangeMiddle - size) && item <= (rangeMiddle + size))
                  yield return item;
           }
        }
