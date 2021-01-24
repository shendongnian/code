    IHandle GetHandle()
    {
      IHandle theHandle = handles.FirstOrDefault(v => v.Item1 == dir.Name).Item2;
  
      if (theHandle == null)
      {
        theHandle = new Handle(dir.Name);
        handles.Enqueue((dir.Name, theHandle));
      }
      return theHandle;
    });
