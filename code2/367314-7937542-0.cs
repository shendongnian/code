      public class Customer
      {
        public string Name { get; set;}
    
        public override int  GetHashCode()
        {
     	    return Name.GetHashCode();
        }
    
        public override bool  Equals(object obj)
        {
          if(obj == null || !(obj is Customer))
            return false;
        
     	    return (obj as Customer).Name.Equals(Name);
        }
      }
      public class UniqueObservableCollection<T> : ObservableCollection<T>
      {
        private Dictionary<T, bool> _itemsDict = new Dictionary<T, bool>();
    
        protected override void  InsertItem(int index, T item)
        {
          if(_itemsDict.ContainsKey(item))
            return;
          _itemsDict.Add(item, true);
     	    base.InsertItem(index, item);
        }
    
        protected override void  ClearItems()
        {
          _itemsDict.Clear();
     	    base.ClearItems();
        }
    
        protected override void  RemoveItem(int index)
        {
          if(index >= base.Items.Count) 
            return;
          var item = base.Items[index];
          if(!_itemsDict.ContainsKey(item))
            return;
          _itemsDict.Remove(item);
     	    base.RemoveItem(index);
        }
      }
