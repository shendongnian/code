    public static void UsingIfNotNull<T>(T item, Action<T> action) where T : class, IDisposable {
      if(item!=null) {
        using(item) {
          action(item);
        }
      }
    }
