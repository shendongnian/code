    public class IndexElliminator<T> {
    
      private List<T> _items;
      private Dictionary<string, List<int>> _index;
      private Func<T, string> _getContent;
    
      private static HashSet<string> GetPairs(string value) {
        HashSet<string> pairs = new HashSet<string>();
        for (int i = 1; i < value.Length; i++) {
          pairs.Add(value.Substring(i - 1, 2));
        }
        return pairs;
      }
    
      public IndexElliminator(List<T> items, Func<T, string> getContent, int maxIndexSize) {
        _items = items;
        _getContent = getContent;
        _index = new Dictionary<string, List<int>>();
        for (int index = 0;index<_items.Count;index++) {
          T item = _items[index];
          foreach (string pair in GetPairs(_getContent(item))) {
            List<int> list;
            if (_index.TryGetValue(pair, out list)) {
              if (list != null) {
                if (list.Count == maxIndexSize) {
                  _index[pair] = null;
                } else {
                  list.Add(index);
                }
              }
            } else {
              list = new List<int>();
              list.Add(index);
              _index.Add(pair, list);
            }
          }
        }
      }
    
      private static List<int> JoinLists(List<int> list1, List<int> list2) {
        List<int> result = new List<int>();
        int i1 = 0, i2 = 0;
        while (i1 < list1.Count && i2 < list2.Count) {
          switch (Math.Sign(list1[i1].CompareTo(list2[i2]))) {
            case 0: result.Add(list1[i1]); i1++; i2++; break;
            case -1: i1++; break;
            case 1: i2++; break;
          }
        }
        return result;
      }
    
      public List<T> Find(string query) {
        HashSet<string> pairs = GetPairs(query);
        List<List<int>> indexes = new List<List<int>>();
        bool found = false;
        foreach (string pair in pairs) {
          List<int> list;
          if (_index.TryGetValue(pair, out list)) {
            found = true;
            if (list != null) {
              indexes.Add(list);
            }
          }
        }
        List<T> result = new List<T>();
        if (found && indexes.Count == 0) {
          indexes.Add(Enumerable.Range(0, _items.Count).ToList());
        }
        if (indexes.Count > 0) {
          while (indexes.Count > 1) {
            indexes[indexes.Count - 2] = JoinLists(indexes[indexes.Count - 2], indexes[indexes.Count - 1]);
            indexes.RemoveAt(indexes.Count - 1);
          }
          foreach (int index in indexes[0]) {
            if (_getContent(_items[index]).Contains(query)) {
              result.Add(_items[index]);
            }
          }
        }
        return result;
      }
    
    }
