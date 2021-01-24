    public class Grouping<K, T> : ObservableCollection<T>
    {
      public K Key { get; private set; }
    
      public Grouping(K key, IEnumerable<T> items)
      {
          Key = key;
          foreach (var item in items)
            this.Items.Add(item);
      }
    }
    
    var sorted = from item in Items
                 orderby item.lvl
                 group item by item.lvl into itemGroup
                 select new Grouping<int, Item>(itemGroup.Key, itemGroup);
    
    //create a new collection of groups
    ItemsGrouped = new ObservableCollection<Grouping<int, Item>>(sorted);
