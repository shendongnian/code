    /// <summary>Function to Set Debug Flag to true if DEBUG is in Effect</summary>
    /// <param name="theDebugFlag">output - true if DEBUG, unchanged if RELEASE</param>
    [Conditional("DEBUG")]
    static void QueryDebugStatus(ref Boolean theDebugFlag)
    {
	theDebugFlag = true;
    }
