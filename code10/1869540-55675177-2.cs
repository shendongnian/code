    KeyedLock _keyedLock;
    async Task ChangeState(bool state)
    {
        using (await this._keyedLock.LockAsync("ChangeState"))
        {
            await OutsideApi.ChangeState(state);
        }
    }
    async Task DoStuff()
    {
        using (await this._keyedLock.LockAsync("DoStuff"))
        {
            await OutsideApi.DoStuff();
        }
    }
