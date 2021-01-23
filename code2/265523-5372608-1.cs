    class Game1 : Game 
    {
      private SpriteBatch spriteBatch;
      private Texture2D cursorTex;
      private Vector2 cursorPos;
    
      
      protected override void LoadContent() 
      {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        cursorTex = content.Load<Texture2D>("cursor");
      }
    
      protected override Update(GameTime gameTime() {
        cursorPos = new Vector2(mouseState.X, mouseState.Y);
      }
    
      protected override void Draw(GameTime gameTime)
      {
        spriteBatch.Begin();
        spriteBatch.Draw(cursorTex, cursorPos, Color.White);
        spriteBatch.End();
      }
    }
