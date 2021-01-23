    protected override void Draw( GameTime gameTime )
    {
        graphics.GraphicsDevice.Clear( Color.CornflowerBlue );
        base.Draw( gameTime );
        MouseState current_mouse = Mouse.GetState();
		Vector2 pos = new Vector2(current_mouse.X, current_mouse.Y);
		
		batch.Draw(tex, pos, Color.White);
    }
