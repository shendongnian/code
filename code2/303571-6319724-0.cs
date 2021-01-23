    // Extension method
    public static class GuiHelpers
    {
        public static void PerformInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
    
    
    // Example of usage
    private void EnableControls()
    {
        panelMain.PerformInvoke(delegate { panelMain.Enabled = true; });
        linkRegister.PerformInvoke(delegate { linkRegister.Visible = true; });
    }
