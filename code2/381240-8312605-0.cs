    interface ICompress
    {
      void Create();
    }
    
    public class AmazingCompressor : ICompress
    {
       public void Create()
       {
          // Call AmazingZipLibrary.Add
       }
    }
    
    public class YetAnotherAmazingCompressor : ICompress
    {
       public void Create()
       {
          // Call YetAnotherAmazingZipLibrary.Compress
       }
    }
