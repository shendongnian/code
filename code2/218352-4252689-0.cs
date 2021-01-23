    [Conditional ("DEBUG")]
    void Log (string msg)
    {
        Console.WriteLine (msg);
    }
    void Foo ()
    {
        Log ("Start");
        ..
        Log ("End");
    }
