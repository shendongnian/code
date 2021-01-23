    public static class ControlExtension
    {
        public static void UpdateControl(this Control control, Action<Control> action)
        {
            if (control.InvokeRequired)
                control.Invoke((Action)(() => action(control)));
            else
                action(control);
        }
    }
