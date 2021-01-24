    public void Test()
    {
        _runners.ForEach(async runner => {
            try { await runner.Test(); }
            catch (Exception e) { Console.Writeln(e.ToString()); }
        });
    }
