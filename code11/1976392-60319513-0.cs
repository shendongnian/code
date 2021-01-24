    class MainClass {
      public static void Main (string[] args) {
        var myCollection = new ObservableCollection<MyClassSelectable>();
    
        // Add some items of tyoe MyClassSelectable to myCollection here
        myCollection.Add(new MyClassSelectable() { Selected = true });
        myCollection.Add(new MyClassSelectable() { Selected = false });
        myCollection.Add(new MyClassSelectable() { Selected = true });
        myCollection.Add(new MyClassSelectable() { Selected = true });
    
    
        // Now get selected or all items
        var selected = GetSelectedItems(myCollection);
    
        Console.WriteLine($"Items selected: {selected.Count()}");
      }
    
      private static IEnumerable<MyClassSelectable> GetSelectedItems(ObservableCollection<MyClassSelectable> coll) {
        var selected = coll.Where(c => c.Selected);
        if (selected.Count() > 0) {
          return selected;
        }
        else {
          return coll;
        }
      }
    }
