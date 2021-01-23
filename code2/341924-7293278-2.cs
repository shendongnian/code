    public abstract class BaseClass 
    {
         public abstract DoWork1();
         public abstract DoWork2();
         public abstract DoWork3();
    
    
         protected void InitializeClass()
         {
            BackgroundWorker bgw1 = new BackgroundWorker();
            bgw1.DoWork += (s,e) =>
            {
               DoWork1();
            };
    
            BackgroundWorker bgw2 = new BackgroundWorker();
            bgw2.DoWork += (s,e) =>
            {
               DoWork2();
            };
    
            BackgroundWorker bgw3 = new BackgroundWorker();
            bgw3.DoWork += (s,e) =>
            {
               DoWork3();
            };
    
            bgw1.RunWorkerAsync();
            bgw2.RunWorkerAsync();
            bgw3.RunWorkerAsync();
        }
    
        
    }
