    public interface IStorage
    {
      bool StoreToFile(string path, string file, byte[] data);
    }
    
    public class Storage : IStorage
    {
      public bool StoreToFile( ... )
      {
         return WriteToFile( ... );
      }
    }
    
    public class StorageMock : IStorage
    {
       public bool StoreToFile (...)
       {
          return false;  //or true, depends on you test case
       }
    }
