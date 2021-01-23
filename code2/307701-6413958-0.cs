     private static void InsertSafe (string item, object @lock)
     {
        lock (@lock)
        {
          mylist.Insert(0,item);
        }
     }
