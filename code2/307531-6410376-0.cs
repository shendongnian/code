    int i=0;
    while (i < list[0].Count) {
      if (list.All(x => x[i] == 0)) {
        foreach (List<int> item in list) {
          item.RemoveAt(i);
        }
      } else {
        i++;
      }
    }
