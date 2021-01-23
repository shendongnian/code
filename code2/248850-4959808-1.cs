    private EventHandler _updateErrorIcons;
    public event EventHandler UpdateErrorIcons
    {
        add
        {
            EventHandler current, original;
            do
            {
                original = _updateErrorIcons;
                EventHandler updated = (EventHandler)Delegate.Combine(original, value);
                current = Interlocked.CompareExchange(ref _updateErrorIcons, updated, original);
            }
            while (current != original);
        }
        remove
        {
            // Same deal, only with Delegate.Remove instead of Delegate.Combine.
        }
    }
