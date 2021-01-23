    class Primary {
      public int x1, x2, x3;   //data that is read from file or calculated
    
      public void DoStuff() {
        x1++; x2--;
      }
    }
    
    public interface PrimaryFactory 
    {
        Primary Load();
    }
    public class FileTypeAPrimaryFactory {
        
        FileTypeAPrimaryFactory(File f) 
        {
           ...
        }
        public void Load() {
            var item = new Primary();
            item.x1 = 2; PrimToLoad.x2 = 4; 
            item.DoStuff(); 
            item.x3 = 6;
        }
    }
    
    class Stub {
      public void SomeMethod() {
        PrimaryFactory factory = new FileTypeAPrimaryFactory(<get file>);
        Primary P = factory.Load();
      }
    }
