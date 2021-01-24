      public void watchFile()
      {
         var watcher = new FileSystemWatcher(@"D:\Projects\APPAR\Budget app\", "PersonList.txt")
         {
            NotifyFilter = NotifyFilters.LastWrite
         };
         watcher.Changed += (sender, args) => RefreshControl(this);
      }
