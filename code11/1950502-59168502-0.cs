    private int _count;
    public int Count => Interlocked.CompareExchange(ref _count, 0, 0);
    private void TaskCallBack(Object ThreadNumber)
    {
        var localCount = Interlocked.Increment(ref _count);
        MessageBox.Show(localCount.ToString());
    }
