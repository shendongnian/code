    protected override void Update(GameTime gameTime)
        {
           // ....
             ProcessKeyboard(); // Calls into ProcessKeyboard()
 
           //....
         }
 
    private void ProcessKeyboard () // A new method
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
             this.Exit(); // Provided from Microsoft.Xna.Framework.Game
        }
        // Handle other keys down here.
    }
