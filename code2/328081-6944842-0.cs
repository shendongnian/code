    private void ViewsMainForm_Load(object sender, System.EventArgs e)
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
