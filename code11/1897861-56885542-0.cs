    private async Task<int> MyMethodHybrid(int i, bool async)
    {
        var r1 = i + 4;
        var r2 = async ?
            await MockDbAccess.GetDbResultAsync(r1) :
            MockDbAccess.GetDbResult(r1);
        var r3 = r1 + r2 * 7;
        return r3;
    }
    public int MyMethod(int i) => MyMethodHybrid(i, false).Result;
    public Task<int> MyMethodAsync(int i) => MyMethodHybrid(i, true);
