    public class CarClass
    {
        // A delegate is a pointer to a function. Events are really a way of late
        // binding delegates, so you need to one of these first to have an event.
        public delegate void GameOverHandler(CarClass sender);
        // an event is a construct which is used to pass a delegate to another object
        // You create an event based for a delegate, and capture it by
        // assigning the function reference to it after the object is created. 
        public event GameOverHandler GameOver;
        void DoGameOver()
        {
           ... do local stuff
           // Make sure ref exists before calling.
           if (GameOver != null) {
             GameOver(this);
           } else {
             throw new Exception("You forgot to bind to the GameOver event.");
           }
        }
    }
    public class MyGames
    {    
    ...
    ...
      CarClass myCar = new CarClass(...); 
      myCar.GameOver += new GameOverHandler(GameOver);
      Main () {
         MyGames game = MyGames(...);
      }
      void GameOver(CarClass sender) {
         // Do stuff
         
      }
    }
