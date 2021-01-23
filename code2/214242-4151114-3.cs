    public static class Alg
    {
       public static void permutations<T>(this T[] elements, Action<T, T> action)
       {
          for (int i=0; i<elements.Length; ++i)
             for (int j=i; j<elements.Length; ++j)
                action(elements[i], elements[j]);
       }
    }
