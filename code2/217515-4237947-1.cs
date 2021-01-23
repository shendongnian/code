     class SomeCollection : IEnumerable
     {
          List<SomeItem> _items = new List<SomeItem>();
          // This is the only code I need to enable this class to participate in foreach loop.
          public Enumerator GetEnumerator()
          {
                return _items.GetEnumerator();
          }
     }
