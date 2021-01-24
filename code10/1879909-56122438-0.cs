    private bool isClicking = false;
    public void SomeEvent()
    {
       if (isClicking) return;
       try
       {
          isClicking = true;
          // do some codes
       }
       finally
       {
          isClicking = false;
       }
    }
