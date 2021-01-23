        spriteBatch.Begin();
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y - 5; y++)
            {
                x = level1[x, 0];
                y = level1[0, y];
                //This line bellow is where it says OutOfMemoryException
                spriteBatch.Draw(tileSheet, new Rectangle(x, y, 32, 32), new Rectangle(0, 0, 32, 32), Color.White);
            }
        }
        spriteBatch.End();
