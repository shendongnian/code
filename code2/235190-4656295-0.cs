    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control c, Action<Control> action)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
        public static void BeginInvokeIfRequired(this Control c, Action<Control> action)
        {
            if (c.InvokeRequired)
            {
                c.BeginInvoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
    }
