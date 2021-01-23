    private string input;
    private bool shiftPressed;
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
        {
            shiftPressed = true;
        }
        else
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                // Number keys pressed so need to so special processing
                // also check if shift pressed
            }
            else
            {
                input += e.Key.ToString();
            }
        }
    }
    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
        {
            shiftPressed = false;
        }
        base.OnKeyUp(e);
    }
