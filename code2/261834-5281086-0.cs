    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (!e.IsRepeat && (e.Key == Key.LeftShift || e.Key == Key.RightShift))
        {
            Trace.WriteLine("Down Shift " + DateTime.Now);
        }
    }
    
    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
        {
            Trace.WriteLine("Up Shift " + DateTime.Now);
        }
    }
