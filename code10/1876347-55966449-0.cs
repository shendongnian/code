    bool isVisible = false;
    PreviewMouseLeftButtonDown += (ss, ee) => 
    {
        if (!passwordBox.IsMouseOver && isVisible)
        {
            System.Diagnostics.Process.GetProcessesByName("CCOnScreenKeyboard")?.FirstOrDefault()?.Kill();
        }
        else if (!isVisible)
        {
            System.Diagnostics.Process.Start("D:\\CCOnScreenKeyboard.exe");
            isVisible = true;
        }
    };
