    for (int i = 0; i < array.Count; i++)
    {
        for (int j = 0; j < array[0].Count; j++)  //assuming always 1 row
        {
           if (array[i][j] == (int)Tiles.Undefined) continue;
           Texture = GetTexture(array[i][j]);  //implement this
           spriteBatch.Draw(Texture, new Vector2(i * Texture.Width, j * Texture.Height), null, Color.White, 0, Origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
