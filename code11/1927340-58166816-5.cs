      public static partial class QueueExtensions {
        public static void MoveToLast<T>(this Queue<int> queue, T itemToMove) {
          if (null == queue)
            throw new ArgumentNullException(nameof(queue)); 
          var list = queue.ToList();
          int index = list.IndexOf(itemToMove);
          if (index < 0)
            return; // Nothing to do
          list.Add(list[index]);
          list.RemoveAt(index);
          queue.Clear();
          foreach (var item in list)
            queue.Enqueue(item);
        }
      }
