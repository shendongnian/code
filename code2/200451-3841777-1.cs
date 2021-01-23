    public class ListBuilder<T> {
      IList<T> _list;
      public ListBuilder(IList<T> list) {
        _list = list;
      }
      public ListBuilder<T> Add(T item) {
        _list.Add(item);
        return this;
      }
    }
