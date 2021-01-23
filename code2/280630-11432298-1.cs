    private static Texture2D rect;
    private void DrawRectangle(Rectangle coords, Color color)
    {
        if(rect == null)
        {
            rect = new Texture2D(ScreenManager.GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.White });
        }
        spriteBatch.Draw(rect, coords, color);
    }
