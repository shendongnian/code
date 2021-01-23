    /// ---- IsDisposable --------------------------------
    ///
    /// <summary>
    /// returns true if an object is disposable, false if not
    /// you can optionally dispose of it immediately
    /// </summary>
    public static Boolean IsDisposable(Object Item, Boolean DeleteIfDisposable)
    {
        if (Item is IDisposable)
        {
            if (DeleteIfDisposable)
            {
                IDisposable DisposableItem;
                DisposableItem = (IDisposable)Item;
                DisposableItem.Dispose();
            }
            return true;
        }
        else
            return false;
    }
