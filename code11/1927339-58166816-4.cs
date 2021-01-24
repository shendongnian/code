      Queue<int> iq = ...
      int itemToMove = 2;
      // Create temporal list
      var list = iq.ToList();
      // process items in it
      int index = list.IndexOf(itemToMove);
      if (index >= 0) {
        list.Add(list[index]);
        list.RemoveAt(index);
      }
      // enqueue items back into queue in the desired order
      iq.Clear();
      foreach (var item in list)
        iq.Enqueue(item);
