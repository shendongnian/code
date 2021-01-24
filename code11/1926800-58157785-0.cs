    private void image1_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.ProcessImageMouseDown(e.ChangedButton, e.ButtonState, e.GetPosition(sender as FrameworkElement));
    }
    private void timerTick(object sender, EventArgs e)
    {
        this.ProcessImageMouseDown(MouseButton.Left, MouseButtonState.Pressed, new Point(10d, 20d));
    }
    private void ProcessImageMouseDown(MouseButton button, MouseButtonState state, System.Windows.Point position)
    {
        // Do actual processing here.
    }
