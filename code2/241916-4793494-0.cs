    bool Enable()
    {
      List<DoStuffDelegate> stuffToDo = new ...
      stuffToDo.Add(myFirstMethod);
      stuffToDo.Add(mySecondMethod);
      foreach(var myDelegate in stuffToDo)
      {
        if(!GetStatus(ref status)) { Trace.WriteLine("Error"); return false; }
        myDelegate(ref status);
      }
    }
