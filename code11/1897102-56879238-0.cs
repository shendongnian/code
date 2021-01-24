spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, layerDepth);
layerDepth accepts any `float` value(the default is 0), **Lower values are rendered on top of higher values**. Any identical values are done in the order entered.
This parameter also applies to `spriteBatch.DrawString()`
**However, `layerDepth` is only valid within the same batch.**  Once `End()` is called the batch is sorted, flattened and rendered to the frame buffer.
Solution
---
Write down the required depths for all of the drawn objects. Replace the `layerDepth` numbers in the following code to reflect your analysis.
Remove all `spriteBatch.Begin()` and `spriteBatch.End()` lines in your entire project. Unless `spriteBatch.Begin()` has non [default][1](Lines 81 and 91-100) parameters.
In `Game1.cs` open the spriteBatch as early as possible after `GraphicsDevice.Clear`:
protected override void Draw(GameTime gameTime)
{
   GraphicsDevice.Clear(Color.CornflowerBlue);
   spriteBatch.Begin();
    
   // Your existing code here.
   spriteBatch.End();
   //oprozniony, nothing should be here
}
In GameScene.cs:
private void DrawGame()
{
// The ,, is for the null source rectangle, 
    spriteBatch.Draw(floor1, rec_floor1,, color1, 0.0f, Vector2.Zero, SpriteEffects.None, 2);
    spriteBatch.Draw(floor2, rec_floor2,, color1, 0.0f, Vector2.Zero, SpriteEffects.None, 3);
    spriteBatch.Draw(house1, rec_house1,,color1, 0.0f, Vector2.Zero, SpriteEffects.None, 1);
// example of a table the animatedSprite(at a depth of 0) will walk or move behind(note the negative depth):
//    spriteBatch.Draw(stol, rec_stol, , color1, 0.0f , Vector2.Zero, SpriteEffects.None, -1);
}
In AnimatedSprite.cs
public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        // unless the width and height can change when the game is running, they should be class variables set in the constructor
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        // removed unnecessary casts:(unless currentFrame is not an int)
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;
        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 120, 140);
        if (Game1.przelacznik_w_bezruchu == true) sourceRectangle = new Rectangle(0, 0, width, height);
        
// Place the sprite at Depth of 0.
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0);        
}
There are situations that will require multiple batches. If that is the case, split the batches by depth order manually.
  [1]: https://github.com/MonoGame/MonoGame/blob/3f472703e0116d1532f1cb71de886e8c75121271/MonoGame.Framework/Graphics/SpriteBatch.cs#L93
