    /// <summary>Creates an instance of the CompareTool.</summary>
    public CompareTool() {
        gsExec = SystemUtil.GetEnvironmentVariable("gsExec");
        compareExec = SystemUtil.GetEnvironmentVariable("compareExec");
    }
