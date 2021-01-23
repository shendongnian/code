    Fire.Event(EventName.WithExceptionHandler(e => false)
                        .Until(e => false).With(this, EventArgs.Empty));
    Fire.Event(EventName.With(this, EventArgs.Empty));
    Fire.Event(EventName.WithExceptionHandler(e => false)
                        .With(this, EventArgs.Empty).Until(e => false));
    Fire.Event(EventName.With(this, EventArgs.Empty)
                        .WithExceptionHandler(e => false).Until(e => false));
