    public static class ContolHelpers
    {
        public static void InvokeIfRequired(this Control control, Action<Control> action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(control);
            }
        }
    }
