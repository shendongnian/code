    public static class Alg
    {
       public static void nonIdentityPermutations<T>(this T[] elements, Action<T, T> action)
       {
          for (int i=0; i<elements.Length; ++i)
             for (int j=i+1; j<elements.Length; ++j)
                action(elements[i], elements[j]);
       }
    }
