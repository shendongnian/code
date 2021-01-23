    public YodaUserControl
    {
      InitializeComponent();
      InitialHeight = parentOfFlp.Height;
    }
    private int InitialHeight { get; }
    private void OnAdded(object sender, ControlEventArgs args)
      => RefreshHeight();
    private void OnRemoved(object sender, ControlEventArgs args)
      => RefreshHeight();
    private void OnSizeChanged(object sender, EventArgs args)
      => RefreshHeight();
    private void RefreshHeight()
    {
      if (flpYoda.Controls.Count > 1
          && flpYoda.Controls[0] is Control control)
      {
        parentOfFlpYoda.Height = flpYoda.Height =
          InitialHeight * (int)Math.Ceiling(
            flpYoda.Controls.Count / Math.Floor(
              flpYoda.ClientSize.Width / (double)control.Width));
      }
    }
