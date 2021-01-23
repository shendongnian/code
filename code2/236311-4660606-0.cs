    var guyTask = new List<Task<bool>>();
    foreach(var guy in guys){
      guyTask.Add(Task.Factory.StartNew(()=>guy.TestForPossibleBadness());
    }
    var guyTaskArr = guyTask.ToArray();
    var running = true;
    while(true){
      var i = Task.WaitAny(guyTaskArr);
      if (!guyTaskArr[i]))
         foreach(var guy in guyTask){
             if (!guy.IsCompleted || !guy.IsFaulted){
                 guy.Cancel();
             }
         }
         return false;
      }else{
         guyTask.Remove(guyTaskArr[i]);
         if (guyTask.Count == 0) return true;
         guyTaskArr = guyTask.ToArray();
      }
    }
