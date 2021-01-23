    using (LowLevelMouseHook hook = new LowLevelMouseHook())
    {
        hook.MouseWheel += (sender, e) =>
        {
            Console.WriteLine(e.Delta);
        };
        Application.Run();
    }
  
