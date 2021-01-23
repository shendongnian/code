    private enum Buttons
    {
      Start = 0,
      Stop = 1,
      Pause = 2,
      /* ... */
    }
    
    private bool IsPressed(Buttons button)
    {
      return Input[(int)button] == 1;
    }
