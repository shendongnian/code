    internal async Task<bool> LongFunction(IProgress<string> progress)
    {
        // Do some magic.
        progress.Report("Something interesting");
        // await ...
        // More magic.
        return true;
    }
