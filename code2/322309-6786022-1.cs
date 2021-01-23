    public void DoWork()
    {
        DoActualWork();
    }
    protected abstract void DoActualWork(); // expected to call DoCommonWork
    protected void DoCommonWork() { ... }
