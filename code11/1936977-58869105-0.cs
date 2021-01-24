    using (DataTarget target = DataTarget.AttachToProcess(Process.GetCurrentProcess().Id, 5000, AttachFlag.Passive))
    {
        ClrRuntime runtime = target.ClrVersions.First().CreateRuntime();
        return new runtime.Threads;
    }
