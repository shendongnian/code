    public static class ArrayExtensions
    {
         public static T[] MergeArrays<T>(this T[] sourceArray, params T[][] additionalArrays)
         {
              List<int> elements = sourceArray.ToList();
              if(additionalArrays != null)
              {
                   foreach(var array in additionalArrays)
                       elements.AddRange(array.ToList());
              }
              return elements.ToArray();
         }
    }
