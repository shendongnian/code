    class FirstClass {
      static private locker = new object();   
      static private List<String> _my_list;
      public static void Add(string item) {
        lock(locker) {
          my_list.Add(item);
        }
      }
      public static void RemoveAt(int index) {
        lock(locker) {
          my_list.RenoveAt(index);
        }
      }
      public static IEnumerable<string> GetEnumerable() {
        lock(locker) {
          List<string> copy = new List<string>(my_list);
          return copy.GetEnumerator();
        }
      }
    }
