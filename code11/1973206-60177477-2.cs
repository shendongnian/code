    public class ObjectWithTimer : IDisposable
    {
       // Flag: Has Dispose already been called?
       private bool _disposed = false;
    
       private int _i;
       public System.Timers.Timer Timer { get; }
       public ObjectWithTimer()
       {
          Timer = new System.Timers.Timer(5000);
          Timer.Elapsed += Obj_Elapsed;
          Timer.Enabled = true;
       }
    
       public void Obj_Elapsed(object sender, ElapsedEventArgs e)
       {
          _i++;
          Console.WriteLine(_i);
       }
    
       // Public implementation of Dispose pattern callable by consumers.
       public void Dispose() =>Dispose(true);
       
    
       // Protected implementation of Dispose pattern.
       protected virtual void Dispose(bool disposing)
       {
          if (_disposed) return; 
          if (disposing) Timer?.Dispose();  
          _disposed = true;
       }
    }
