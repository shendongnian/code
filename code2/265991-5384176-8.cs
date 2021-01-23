    static TypeHashes _type = new TypeHashes(typeof(Program));        
    private void Run()
    {
        TracerConfig.Reset("debugoutput");
        using (Tracer t = new Tracer(_type, "Run"))
        {
            for (int i = 0; i < 4; i++)
            {
                DoSomeThingAsync(i);
            }
        }
        Application.Run();  // Start window message pump to prevent termination
    }
        
    private async void DoSomeThingAsync(int i)
    {
        using (Tracer t = new Tracer(_type, "DoSomeThingAsync"))
        {
            t.Info("Hi in DoSomething {0}",i);
            try
            {
                int result = await Calculate(i);
                t.Info("Got async result: {0}", result);
            }
            catch (ArgumentException ex)
            {
                t.Error("Got argument exception: {0}", ex);
            }
        }
    }
    Task<int> Calculate(int i)
    {
        var t = new Task<int>(() =>
        {
            using (Tracer t2 = new Tracer(_type, "Calculate"))
            {
                if( i % 2 == 0 )
                    throw new ArgumentException(String.Format("Even argument {0}", i));
                return i++;
            }
        });
        t.Start();
        return t;
    }
