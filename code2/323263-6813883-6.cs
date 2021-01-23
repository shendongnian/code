    public void Draw(SpriteBatch theSpriteBatch, Vector2 positonOnScreen)
        {
            positonOnScreen = new Vector2(positonOnScreen.X * base.Scale * 16,
            positonOnScreen.Y * base.Scale * 16);
            //base.Scale is just a variable for have the ability to zoom in/out
            //16 represents the original size of the picture (16x16 pixels)
            theSpriteBatch.Draw(mSpriteTexture, new Rectangle((int)positonOnScreen.X,
            (int)(positonOnScreen.Y), 64, 64),new Rectangle(0, 0, 16, 16), Color.White);
         }
