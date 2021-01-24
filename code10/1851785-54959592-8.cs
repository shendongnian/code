    IHandle GetHandle(Dir dir, int handleOpenAttemps = 1)
    {
      if(handles.TryGetValue(dir.Name, out (IHandle, int) handle))
      {
        handle.Item2++;
      }
      else
      {
    
        if(new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes").NextValue() < YOUR_TRESHHOLD)
        {
          FreeResources();
        }
    
        try
        {
          handle.Item1 = new Handle(dir.Name);
        }
        catch (OutOfMemoryException)
        {
    
          if (handleOpenAttemps == 2)
          {
            return null;
          }
    
          FreeResources();
          return GetHandle(dir, handleOpenAttemps++);
        }
        catch (Exception)
        {
          // Your handling.
        }
    
        handle.Item2 = 1;
        handles.TryAdd(dir.Name, handle);
      }       
    
      return handle.Item1;
    }
