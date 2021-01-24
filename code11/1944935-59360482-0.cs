    /// <summary>
    /// Gets an <see cref="T:OpenQA.Selenium.IMouse" /> object for sending mouse commands to the browser.
    /// </summary>
    [Obsolete("This property was never intended to be used in user code. Use the Actions or ActionBuilder class to send direct mouse input.")]
    public IMouse Mouse
    {
      get
      {
        return this.mouse;
      }
    }
    /// <summary>
    /// Gets an <see cref="T:OpenQA.Selenium.IKeyboard" /> object for sending keystrokes to the browser.
    /// </summary>
    [Obsolete("This property was never intended to be used in user code. Use the Actions or ActionBuilder class to send direct keyboard input.")]
    public IKeyboard Keyboard
    {
      get
      {
        return this.keyboard;
      }
    }
