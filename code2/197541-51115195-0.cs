    private System.Collections.Generics.Queue<string> _argsQ;
    public void InitArgs()
    {
        _argsQ = new System.Collections.Generics.Queue<string>();
    }
    public void PushArg(string arg)
    {
        _argsQ.Enqueue(arg);
    }
    public void FinalArgs()
    {
        string[] parameters = _argsQ.ToArray();
        // Save parameters
    }
