    List<NewData> list = ...
    // If list is not guarantee to be sorted
    list.Sort((a, b) => a.MONTH.CompareTo(b.MONTH));
    for (int i = 0; i < list.Count - 1; ++i) {
      NewData current = list[i];
      NewData next = list[i + 1];     
      // Do we have a hole at position i + 1? 
      if (current.MONTH + 1 < next.MONTH) {
        list.Insert(i + 1, new NewData() {
          MONTH = current.MONTH + 1,  // Omitted month
          NEW_REC_COUNT = 0,          // Default value
        });
      }
    }
