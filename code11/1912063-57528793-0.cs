    var sw = new Stopwatch();
    sw.Start();
    var pid = new PidController(1f, 0f, 0f) { SetPoint = 100f };
    var proc = new SimpleProcess();
    // pid.Dump();
    // proc.Dump();
    var values = new List<ProcessValue>();
    for (int i = 0; i < 50; i++)
    {
        var actual = proc.Output;
        var controlValue = pid.GetControlValue(actual);
        if(sw.IsRunning){
            sw.Stop();
            sw.ElapsedTicks.Dump();
        }
