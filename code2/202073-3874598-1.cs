    void StepThroughDirectories(string dir)
    {
        StepThroughDirectories(dir, 0)
    }
    void StepThroughDirectories(string dir, int currentDepth)
    {
        // process 'dir'
        ...
        // process subdirectories
        if (currentDepth < MaximumDepth)
        {
            foreach (string subdir in Directory.GetDirectories(dir))
                StepThroughDirectories(subdir, currentDepth + 1);
        }
    }
