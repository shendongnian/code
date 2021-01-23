    public class Example
    {
      private List<string> master = new List<string>();
      private volatile List<string> snapshot = new List<string>();
    
      public void Write(string item)
      {
        lock (master)
        {
          master.Add(item); // Modify the master data structure.
          var copy = new List<string>(master); // Create the copy.
          snapshot = copy; // Swap out the snapshot reference.
        }
      }
    
      public string Read(int index)
      {
        return snapshot[index];
      }
    }
