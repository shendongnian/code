    public static class ControlExtensions
    {
        public static TControl FindControlRecursive<TControl>
        (
            this ControlCollection controls
        ) where TControl : Control
        {
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    var foundControl = control as TControl 
                        ?? control.Controls.FindControlRecursive();
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            return null;
        }
    }
