    class paddle
    {
        public Vector2 paddlePosition;
        public Texture2D pongPaddle; 
 
        // Getting Paddle Height and Width
 
        public int Width
        {
            get { return pongPaddle.Width; }
        }
 
 
        public int Height
        {
            get { return pongPaddle.Height; }
        }
 
 
        public paddle(Texture2D texture, Vector2 position)
        {
            pongPaddle = texture;
 
            //Set Paddle position
            paddlePosition = position;
        }
 
        public void Update()
        {
        }
 
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pongPaddle, paddlePosition, null, Color.DarkSlateBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
