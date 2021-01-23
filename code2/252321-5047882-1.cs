    private void Foo() {
      List<Item> result = new List<Item>();
      foreach(var item in items) {
        if (!item.IsBad) {
          result.Add(item); // we are adding to a collection other
                            // than the one we are iterating through
        }
      }
      items = result; // we are no longer iterating, so we can modify
                      // this collection
    }
