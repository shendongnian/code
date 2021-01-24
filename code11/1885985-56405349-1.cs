    public class Game1 : Game
    {
        Player player;
        GameTime myElapsed;
        
        public Game1()
        {
            //
        }
        
        protected override void LoadContent()
        {
            //Load your animated sprite here
            myPlayerAnim = Content.Load<Texture2D>("SpriteSheetPlayerAnim");
            
            player = new Player(myElapsed, myPlayerAnim, ...);//constructor with attributes here or whatever you want
        }
        
        protected override void Update(GameTime gameTime)
        {
            myElapsed += (float)aGameTime.ElapsedGameTime.TotalMilliseconds;
            player.Update(gameTime);
        }
        
        protected override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
