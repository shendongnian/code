    void StepThroughDirectories(string dir)
    {
        StepThroughDirectories(dir, 0)
    }
    void StepThroughDirectories(string dir, int currentDept)
    {
        // process 'dir'
        ...
        // process subdirectories
        if (currentDepth < MaximumDepth)
        {
            foreach (string subdird in Directory.GetDirectories(dir))
                StepThroughDirectories(subdir, currentDepth + 1);
        }
    }
