    class Game
    {
      public event EventHandler SomeEvent;
      List<Sprite> sprites;
    
      public Game()
      {
        sprites = new List<Sprite>();
        sprites.Add(new Sprite(this));
        sprites.Add(new Sprite(this));
        sprites.Add(new Sprite(this));
        sprites.Add(new Sprite(this));
    
        sprites.RemoveAt(0);
    
        EventHandler temp = SomeEvent;
        if (temp != null)
        {
            temp(this, EventArgs.Empty);
        }
      }
            
      static void Main(string[] args)
      {
          Game newProgram = new Game();
      }
        
    
    
      class Sprite
      {
          public Sprite(Game gameReference)
          {
              gameReference.SomeEvent += new EventHandler(gameReference_SomeEvent);
          }
    
          void gameReference_SomeEvent(object sender, EventArgs e)
          {
              Debug.WriteLine("Event");
          }    
      }
