    // Event handler
    private void ControlsSizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
    {
        GetFontSize(sender as Control);
    }
    
    // Method for font size changes
    public static void GetFontSize(Control control)
    {
        PropertyInfo info;
        if (control == null || control.ActualHeight <= 0)
            return;
        if(( info = control.GetType().GetProperty("FontSize", typeof(double))) != null)
        {
            info.SetValue(control, 0.7 * control.ActualHeight, null);
        }
    }
