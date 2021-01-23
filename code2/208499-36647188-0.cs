    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        try
        {
            Rect workArea = SystemParameters.WorkArea;
            this.Left = (workArea.Width - e.NewSize.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - e.NewSize.Height) / 2 + workArea.Top;
        }
        catch (Exception ex) { ... Handel exception; }
    }
