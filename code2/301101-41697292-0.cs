        Assembly assem = Assembly.LoadFrom(File.ReadAllBytes(filePath));
        sw = Stopwatch.StartNew();
        var types1 = assem.GetTypes();
        sw.Stop();
        double time1 = sw.Elapsed.TotalMilliseconds;
