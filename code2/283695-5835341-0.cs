           public void Initialize(Texture2D texture, Vector2 position)
           {
                pongPaddle1 = texture;
     
                //Set Paddle position
                paddle1Position = position;
           }
     
     
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(pongPaddle1, paddle1Position, null, Color.DarkSlateBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
