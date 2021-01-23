    var currentMouseState = Mouse.GetState();
    
    if (currentMouseState.LeftButton == ButtonState.Pressed &&
    previousMouseState.LeftButton != ButtonState.Pressed)
    {
    	Vector2 mousePosition = new Vector2(currentMouseState.X,currentMouseState.Y);
    	
    	mousePosition-=sprite.Position;
    	
        /// .Bounds is a property of Texture2D, and returns a Rectangle() struct
        var spriteWasClicked = sprite.Bounds.Contains(mousePosition.X,mousePosition.Y);
    		
    	if(spriteWasClicked)
    	{
    		xpos = rnd.Next(windowWidth - texture.Width);
    		ypos = rnd.Next(windowHeight - texture.Height);
    		
    		// update sprite position with to xpos,ypos here.
    	}
    	
    }
    
    previousMouseState = currentMouseState;
