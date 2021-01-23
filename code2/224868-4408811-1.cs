    ProcessingResult ProcessFiles(IEnumerable<Foo> files)
    {
        List<Foo> failures = new List<Foo>();
        ProcessingResult result = new ProcessingResult(files, failures);
        foreach (var foo in files)
        {
            // voodoo
            if (error)
                failures.Add(foo);
        }
        return result;
    }
