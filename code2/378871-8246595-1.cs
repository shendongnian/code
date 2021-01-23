    public class Example
    {
      private volatile List<string> data = new List<string>();
    
      public void Write(string item)
      {
        lock (data)
        {
          var copy = new List<string>(data); // Create the copy.
          copy.Add(item); // Modify the data structure.
          data = copy; // Publish the modified data structure.
        }
      }
    
      public string Read(int index)
      {
        return data[index];
      }
    }
