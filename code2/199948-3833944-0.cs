    [Serializable]
    public class MySerializableClass {
    }
    
    public sealed class MyStorage : IDisposable {
    
      ~MyStorage()
      {
         Dispose(false);
      }
    
    
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
    
    
      void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if (disposing)
            {
              //We can access to all managed resources
              using (var ms = new MemoryStream())
              {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, mySerializableClass);
                byte[] output = Dostuff(ms);
                File.WriteAllBytes(DBPATH, output);
              }
            }
            else
            {
               //Inappropriate storage usage!
               //We can't guarantee that mySerializableClass object would
               //properly saved to persistant storage.
               //Write warning to log-file. We should fix our code
               //and add appropriate usage!
            }
        }
        this.disposed = true;
     }
    
    }
