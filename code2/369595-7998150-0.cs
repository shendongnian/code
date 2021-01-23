    _tasks.ForEach(i=>
    {
     i.Factory.StartNew(()=>
     {
      _bullets.Where(j=> _bullets.IndexOf(j)%_tasks.IndexOf(i)==0 && j.Active).Update();
     }
    }
    );
