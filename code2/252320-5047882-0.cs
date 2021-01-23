    private void Foo() {
      foreach(var item in items) {
        if (item.IsBad) {
          DeleteItem(item); // will throw an exception as it tries to modify items
        }
      }
    }
    
    private void DeleteItem(Item item) {
      items.Remove(item);
    }
