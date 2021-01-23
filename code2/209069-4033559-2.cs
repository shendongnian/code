    public class CarClass
    {
        // A delegate is a pointer to a function. Events are really a way of late
        // binding delegates, so you need to one of these first to have an event.
        public delegate void ExplodedHandler(CarClass sender);
        // an event is a construct which is used to pass a delegate to another object
        // You create an event based for a delegate, and capture it by
        // assigning the function reference to it after the object is created. 
        public event ExplodedHandler Exploded;
        protected void CarCrash()
        {
           ... do local stuff
           // Make sure ref exists before calling; if its required that something
           //  outside this object always happen as a result of the crash then 
           // handle the other case too (throw an error, e.g.)
           if (Exploded!= null) {
             Exploded(this);
           } 
        }
    }
    public class MyGames
    {    
    ...
    ...
      CarClass myCar = new CarClass(...); 
      myCar.Exploded += new ExplodedHandler(GameOver);
      Main () {
         MyGames game = MyGames(...);
      }
      void GameOver(CarClass sender) {
         // Do stuff
         
      }
    }
