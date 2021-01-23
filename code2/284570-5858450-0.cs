    public delegate void ClickedHandler(object sender, EventArgs e);
    public event ClickedHandler Clicked;
    private void OnClidked()
    {
      if (Clicked != null)
      {
         Clicked(this, EventArgs.Empty);
      }
    }
