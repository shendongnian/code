    Action a;
    for(var index = 0; index < Constratins.Count; index++)
    {
       if(!c.Allows(a))
       {
          a.Change();
          index = -1; // restart
       }
    }
