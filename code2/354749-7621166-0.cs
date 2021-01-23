    Vector2 pos = Vector2.Zero;
    spriteBatch.Begin(...,....,...,..., Transform);
    spriteBatch.Draw(LeftTexture, pos, null, Color.White);
    pos.X += LeftTexture.Width;
    for (int i=0; i<floor_repeats; i++)
    {
        spriteBatch.Draw(MidleTexture, pos , null, Color.White);
        pos.X += MiddleTexture.Width; 
    }
    spriteBatch.Draw(RightTexture, pos , null, Color.White);
     
