    public void Foo()
    {
        MiniProfiler.Start("Interesting subroutine");
        using (MiniProfiler.Current.Step("Step1"))
        {
            using (MiniProfiler.Current.Step(nameof(AccessDb)))
            {
                AccessDb();
            }
            Thread.Sleep(100);
        }
        using (MiniProfiler.Current.Step("Step2"))
        {
            Thread.Sleep(100);
        }
        MiniProfiler.Stop();
        Console.WriteLine(MiniProfiler.Current.RenderPlainText());
    }
