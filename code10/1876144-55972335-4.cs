    public bool ThorwExceptionOnSubscribingShownEvent { get; set; } = true;
    public new event EventHandler Shown
    {
        add
        {
            if (ThorwExceptionOnSubscribingShownEvent)
                throw new InvalidOperationException("Shown event is deprecated.");
            base.Shown += value;
        }
        remove
        {
            base.Shown -= value;
        }
    }
