    // Presumably in Update or LoadContent:
    using(FileStream stream = File.OpenRead("uploaded.png"))
    {
        myTexture = Texture2D.FromStream(GraphicsDevice, stream);
    }
    // In Draw:
    spriteBatch.Begin();
    spriteBatch.Draw(myTexture, new Vector2(111), new Rectangle( 0,  0, 50, 50), Color.White);
    spriteBatch.Draw(myTexture, new Vector2(222), new Rectangle( 0, 50, 50, 50), Color.White);
    spriteBatch.Draw(myTexture, new Vector2(333), new Rectangle(50,  0, 50, 50), Color.White);
    spriteBatch.Draw(myTexture, new Vector2(444), new Rectangle(50, 50, 50, 50), Color.White);
    spriteBatch.End();
