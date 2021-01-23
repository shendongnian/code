    public void Run()
    {
       myParse.DoWork(a => UpdateProgressBar(a.Progress));
    }
    private void UpdateProgressBar(int progress) { ... }
