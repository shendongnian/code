            class TestMemoryLeak : IDisposable
            {
                  public event EventHandler AnEvent;
                  private bool disposed = false;
               internal TestMemoryLeak()
               {
                     AnEventListener leak = new AnEventListener();
                     this.AnEvent += (s, e) => leak.OnLeak();
                    AnEvent(this, EventArgs.Empty);
               }
               protected virtual void Dispose(bool disposing)
               {
                  if (!disposed)
                   {
                     if (disposing)
                     {
                          this.AnEvent -= (s, e) => leak.OnLeak();
                     }
                     this.disposed = true;
                    }
                   
                }
            
               public void Dispose() 
               {
                    this.Dispose(true);
                    GC.SupressFinalize(this);
               }
        }
