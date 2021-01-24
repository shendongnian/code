    public static class Extensions
    {
       public static IEnumerable<T> GetColumn<T>(this T[,] array, int col)
       {
          for (var i = 0; i < array.GetLength(0); i++)
             yield return array[i, col];
       }
    }
