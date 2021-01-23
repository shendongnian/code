    class MyGame
    {
      public int screenWidth;
      public int screenHeight;
      void MainLoop()
      {
         Paddle p = new Paddle(this);
      }
    }
    class Paddle
    {
      MyGame game;
      
      public Paddle(MyGame game)
      {
         this.game = game;
      }
      void Initialize()
      {
         int w = game.screenWidth;
         int h = game.screenHeight;
      }
    }
