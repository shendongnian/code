    public class Player
    {
        //Default constructor
        public Player()
        {
            //default values for your player//for example only
            //this.hp = 100;
            //this.mp = 20;
        }
        
        //Constructor
        public Player(GameTime myelapsedGameTime, Texture2D texPlayer, Vector2 playerPosition, int something, Vector2 vector2ForSomething, int intFST, Color playerColor, ...)
        {
            //initialise player's attributes
            
        }
        
        public override Update(GameTime gameTime)
        {
            if (myElapsed >= myDelay)
            {
                if (myFrames >= 3)
                {
                    myFrames = 0;
                }
                else
                {
                    myFrames++;
                }
                myElapsed = 0;
            }
        }
        
        public override Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myPlayerAnim, myDestRect , mySourceRect, 
                Color.White);//for example
        }
    }
