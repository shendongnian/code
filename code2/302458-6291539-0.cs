    public class Data : IDisposable
    {
       public event EventHandler OnSave;
    
       //other members
    
       public void Dispose()
       {
          if (OnSave != null)
          {
              //yes there is
          }
       }
    }
