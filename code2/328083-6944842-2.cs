    private void YourForm_Load(object sender, System.EventArgs e)
    {
      if (IsTouchScreen)
      {
        ArrangeControlsForTouchScreen();
      }
      else
      {
        ArrangeControlsForPlainScreen();
      }
    }
