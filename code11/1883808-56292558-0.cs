    this.PropertyChanged += async (s, e) =>
    {
        if (e.PropertyName == nameof(SomeInteger))
        {
            await SomeAsyncMethod();
        }
    };
