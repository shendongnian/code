    private static void OnMouseLeftButtonUp(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            IntPtr hWnd = GetWindowUnderCursor();
            SetForegroundWindow(hWnd);
            Thread.Sleep(500);
    
            Thread.Sleep(1000); // It's necessary to wait some time before sending new keysrokes
    
            new InputSimulator().Keyboard. 
                .ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
            Thread.Sleep(500);
            MessageBox.Show(Clipboard.GetText());
        }
    }
