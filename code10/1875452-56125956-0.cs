    public class InputManager
    {
    	KeyboardState currentKeyboard, previousKeyboard;
    	MouseState currentMouse, previousMouse;
    	
    	public bool LeftKeyIsHeldDown { get; private set; }
    	public bool RightKeyIsHeldDown { get; private set; }
    	public bool JumpWasJustPressed { get; private set; }
    	public bool FireWasJustPressed { get; private set; }
    
    	public void Update()
    	{
    		previousKeyboard = currentKeyboard;
    		currentKeyboard = Keyboard.GetState();
    
    		previousMouse = currentMouse;
    		currentMouse = Mouse.GetState();
    		
    		LeftKeyIsHeldDown = currentKeyboard.IsKeyDown(Keys.A);
    		RightKeyIsHeldDown = currentKeyboard.IsKeyDown(Keys.D);
    		JumpWasJustPressed =  currentKeyboard.IsKeyDown(Keys.Space) && previousKeyboard.IsKeyUp(Keys.Space);
    		FireWasJustPressed = currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released;
    	}
    }
