    protected async Task NestedMethodUpdate()
    {
        await NestedUpdate(++nestedCounter);
        await Task.Delay(1000);
        await NestedUpdate(++nestedCounter);
        StatehasChanged();  // <<-- add this
        await Task.Delay(1000);
        await NestedUpdate(++nestedCounter);
    }
