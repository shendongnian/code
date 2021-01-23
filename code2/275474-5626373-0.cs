    List<Task> tasks =
    (from c in yourDirList select new Action(() =>
     {
      try
      {
       // do it
      }
      catch (Exception e)
      {
       // log it
      }
     })
     into action
     select Task.Factory.StartNew(action)).ToList();
    tasks.ForEach(c => c.Wait());
