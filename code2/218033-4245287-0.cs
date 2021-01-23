    using (var dest = File.CreateText(path))
    {
        while (loopCondition)
        {
            // snip
            dest.WriteLine(nextLineToWrite);
        }
    }
