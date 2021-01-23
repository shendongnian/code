    var versions = new [] { "3.0.0.0", "3.1.0.0", "4.0.1.0", "4.0.1.2" };
    foreach (var version in versions.Select(Version.Parse)
                                    .OrderByDescending(v => v))
    {
        Console.WriteLine("{0}", version);
    }
    // Group them by Major Version first, then sort
    foreach (var major in versions.Select(Version.Parse)
                                  .GroupBy(v => v.Major)
                                  .OrderByDescending(g => g.Key))
    {
        Console.WriteLine("{0}: {1}",
                          major.Key,
                          String.Join(", ", major.OrderByDescending(v => v)));
    }
