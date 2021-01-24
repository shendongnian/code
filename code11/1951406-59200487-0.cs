    public static IEnumerable<T> FirstEqual(this IEnumerable<T> source)
    {
          var e = source.GetEnumerator();
          if (e.MoveNext())
          {
              T first = e.Current;
              yield return first;
              while (e.MoveNext())
              {
                 if (e.Current.Equals(first))
                    yield return first;
                  else 
                     break;
              }
          }
    }
