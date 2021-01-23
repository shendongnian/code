    var currentMouseState = Mouse.GetState();
    
    if (currentMouseState.LeftButton == ButtonState.Pressed &&
    previousMouseState.LeftButton != ButtonState.Pressed)
    {
    	Vector2 mousePosition = new Vector2(currentMouseState.X,currentMouseState.Y);
    	
    	mousePosition-=sprite.Position;
    	
    	var spriteWasClicked = 
    		mousePosition.X >= 0 
    		&& mousePosition.X < sprite.Width
    		&& mousePosition.Y >= 0
    		&& mousePosition.Y < sprite.Height
    		;
    		
    	if(spriteWasClicked)
    	{
    		xpos = rnd.Next(windowWidth - texture.Width);
    		ypos = rnd.Next(windowHeight - texture.Height);
    		
    		// update sprite position with to xpos,ypos here.
    	}
    	
    }
    
    previousMouseState = currentMouseState;
