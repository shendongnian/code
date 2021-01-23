    public static void Save(OrderInfo item) {
      for (int i = 0; i < item.Count; i++) {
        if (item[i].Changed) {
          item[i].Save();
        }
      }
      if (item.Changed) {
        item.Changed = false; // prevents recursion!
        item.Save();
        if error saving then item.Changed = true; // reset if there's an error
      }
    }
