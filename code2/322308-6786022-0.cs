    public void DoWork()
    {
        DoBeforeWork();
        DoCommonWork();
        DoAfterWork();
    }
    protected abstract void DoBeforeWork();
    protected abstract void DoAfterWork();
    private void DoCommonWork() { ... }
