    public class CarClass
    {
        // a delegate is a pointer to a function.
        public delegate void GameOverHandler(CarClass sender);
        // an event is a construct which is used to pass a delegate to another object
        // You create an event based on a delegate, and capture it by
        // assigning the function reference to it after the object is created.
        public event GameOverHandler GameOver;
        void DoGameOver()
        {
           ... do local stuff
           // Make sure ref exists before calling
           if (GameOver != null) {
             GameOver(this);
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
