    public static T[] RemoveFirstElement<T>(this T[] array)
    {
       if (array == null)
       {
         throw new ArgumentNullException(nameof(array));
       }
       else if (array.Length == 0)
       {
           return array;
       }
       else
       {
           return array.Skip(1).ToArray();
       }
    }
