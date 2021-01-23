    protected override void Update(GameTime gameTime)
    {
    	// Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
    	{
    		this.Exit();
    	}
        
    	// Get current mouseState
    	mouseStateCurrent = Mouse.GetState();
        
        // Left MouseClick
        if (mouseStateCurrent.LeftButton == ButtonState.Pressed)
        {
    		// TODO when left mousebutton clicked
        }
        
        // Right MouseClick
        if (mouseStateCurrent.RightButton == ButtonState.Pressed && mouseStatePrevious.RightButton == ButtonState.Released)
        {
    		//TODO when right mousebutton clicked
        }
    	
    	mouseStatePrevious = mouseStateCurrent;
    	
    	
    	// Update
    	base.Update(gameTime);
    }
  
