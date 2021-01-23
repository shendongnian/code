    public static class ControlHelpers
    {
        public static void InvokeIfRequired(this ISynchronizeInvoke control, Action<ISynchronizeInvoke> action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)));
            }
            else
            {
                action(control);
            }
        }
    }
