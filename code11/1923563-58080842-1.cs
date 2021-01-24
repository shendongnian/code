    /// <summary>
    /// Gets the Excel instance running in the given process, or null if none exists.
    /// </summary>
    /// <param name="process">The process.</param>
    public static Excel.Application AsExcelApp(this Process process)
    {
        if (process == null) throw new ArgumentNullException(nameof(process));
        var handle = process.MainWindowHandle.ToInt32();
        var result = NativeMethods.AppFromMainWindowHandle(handle);
        //Debug.Assert(result != null);
        return result;
    }
