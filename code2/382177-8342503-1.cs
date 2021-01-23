    public class Example
    {
      private BlockingCollection<int> commands = new BlockingCollection<int>();
      
      public Example()
      {
        var thread = new Thread(Run);
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void SendCommmand(int command)
      {
        commands.Add(command);
      }
    
      private void Run()
      {
        while (true)
        {
          int command = commands.Take();
          ProcessCommand(command);      
        }
      }
      
      private void ProcessCommand(int command)
      {
        // Process the command here.
      }
    }
