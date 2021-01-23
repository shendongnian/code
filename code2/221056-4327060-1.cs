    /// <summary>
    /// Registers the specified path for probing.
    /// </summary>
    /// <param name="path">The probable path.</param>
    private void RegisterPath(string path)
    {
        AppDomain.CurrentDomain.AppendPrivatePath(path);
    }
