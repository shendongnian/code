    // T1:
    somethingChanged(string path, CT commandType)
    {
      commandQueue.AddCommand(path, commandType);
    }
    
    // T2:
    while (whatever)
    {
      var command = commandQueue.Peek();
      if (command.Execute()) commandQueue.Remove();
      else // operation failed, do what you like.
    }
