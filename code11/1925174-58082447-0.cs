    public virtual async Task<bool> TrySomething()
    {
        var args = new MyEventArgs();
        SomeEvent?.Invoke(this, args);
        return await (args.Success ?? Task.FromResult(false));
    }
