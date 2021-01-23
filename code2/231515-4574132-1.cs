    Action a;
    for(var index = 0; index < Constratins.Count; index++)
    {
       if(!Constraints[index].Allows(a))
       {
          a.Change();
          index = -1; // restart
       }
    }
