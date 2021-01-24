    public static Control GetParentRecursive<T>(Control myControl)
    {
        Control rControl = null;
        if (myControl.Parent != null)
        {
            if (myControl.Parent.GetType() == typeof(T))
            {
                rControl = myControl.Parent;
            }
            else
            {
                rControl = GetParentRecursive<T>(myControl.Parent);
            }
        }
        else
        {
            rControl = null;
        }
        return rControl;
    }
