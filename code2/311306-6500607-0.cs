    public static class ControlEx
    {
        public static void Invoke(this System.Windows.Forms.Control @this, Action action)
        {
            if (@this == null) throw new ArgumentNullException("@this");
            if (action == null) throw new ArgumentNullException("action");
            if (@this.InvokeRequired)
            {
                @this.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
