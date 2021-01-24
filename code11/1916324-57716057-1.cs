csharp
public static IEnumerable<string> Split(string text, double rectangleWidth)
{
    var words = text.Split(' ');
    string buffer = string.Empty;
    
    foreach (var word in words)
    {
       var newBuffer = buffer + " " + word;
       
       if (Measure(newBuffer) >= rectangleWidth)
       {
           yield return buffer;
           buffer = word;
       }
       else
       {
           buffer = newBuffer;
       }
    }
}
To get the lines as an array, use ``string[] lines = Split(text, Rectangle.Width).ToArray()``.
If you want a single string separated by newlines, use ``string boxedText = string.Join('\n', Split(text, Rectangle.Width))``.
In your case you would use it like this:
csharp
string Text = "Cyberpunk 2077 is an upcoming role-playing video game developed and published by CD Projekt, releasing for Google Stadia, Microsoft Windows, PlayStation 4, and Xbox One on 16 April 2020. Adapted from the 1988 tabletop game Cyberpunk 2020, it is set fifty-seven years later in dystopian Night City, an open world with six distinct regions. In a first-person perspective, players assume the role of the customisable mercenary V, who can reach prominence in hacking, machinery, and combat. V has an arsenal of ranged weapons and options for melee combat.";
protected override void Draw(GameTime gameTime)
{                
    graphics.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
    spriteBatch.Begin();
    spriteBatch.DrawString(
        Font, 
        string.Join(' ', Split(Text, Rectangle.Width)), 
        new Vector2(200, 300), 
        Microsoft.Xna.Framework.Color.White, 
        0, 
        Vector2.Zero,
        1f,
        SpriteEffects.None,
        0f);
    spriteBatch.End();
    base.Draw(gameTime);
}
