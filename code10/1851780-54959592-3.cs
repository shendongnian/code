    IHandle GetHandle(Dir dir)
    {
      if(handles.TryGetValue(dir.Name, out (IHandle, int) handle))
      {
        handle.Item2++;
      }
      else
      {
        try
        {
          handle.Item1 = new Handle(dir.Name);
        }
        catch (OutOfMemoryException)
        {
          FreeResources();
          return GetHandle(dir);
        }
    
        handle.Item2 = 1;
        handles.TryAdd(dir.Name, handle);
      }       
    
      return handle.Item1;
    }
