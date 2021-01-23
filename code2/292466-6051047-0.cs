    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)            
        {            
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
