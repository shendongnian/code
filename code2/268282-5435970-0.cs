    public class Simple{    
      private IList<string> entries;
    
      public IList<string> Entries { 
        get { return entries; }
      } 
    
      public Simple() {
        entries= new List<string>();    
      }
    }
