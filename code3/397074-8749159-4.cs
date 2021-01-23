    public Task Submit(FileInfo file)
    {
        return Task.Factory.StartNew(() => DoSomething(file));
    }
    private void DoSomething(FileInfo file)
    {
        throw new Exception();
    }
