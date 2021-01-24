    public class MyTimerReference {
       private Temp temp = null;
       public Temp Value { 
          get {
              return temp;
          } 
          set {
              var oldRef = temp;
              if (value != null)
                  value.AddRef();
              temp = value;
              if (oldRef != null)
                  oldRef.ReleaseRef();   
          }
       }
    }
    
    public class Temp
    {
        public int ID { get; set; } = 0;
        public System.Timers.Timer Timer { get; set; } = null;
    
        public Temp(int id)
        {
            ID = id;
            Timer = new System.Timers.Timer(5000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.Start();
            Console.Write(this.ID + "Class Constructor");
        }
    
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.Write(this.ID + "Timer_Elapsed");
        }
    
        private int refCount = 0;
        void AddRef() {
           refCount++;
        }
    
        void ReleaseRef() {
           refCount--;
           if (refCount == 0) {
              Timer.Stop();
              Console.Write(this.ID + "stopped");
           }
        }
    }
