    public static class ControlExtensions
    {
        public static TControl FindControlRecursive<TControl>
        (
            this ControlCollection controls,
            Predicate<TControl> matchPredicate = null
        ) where TControl : Control
        {
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    var foundControl = control as TControl 
                        ?? control.Controls.FindControlRecursive(matchPredicate);
                    if (foundControl != null)
                    {
                        if (matchPredicate != null && !matchPredicate(foundControl))
                        {
                            continue;
                        }
                        return foundControl;
                    }
                }
            }
            return null;
        }
    }
