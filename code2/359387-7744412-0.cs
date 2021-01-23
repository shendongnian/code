    String url = @"http://example.com/TIGS/SIM/Lists/Team Discussion/DispForm.aspx?ID=1779";
    System.Uri uri = new System.Uri(url);
    String dir = Path.GetDirectoryName(uri.AbsolutePath);
    String[] parts = dir.Split(new[]{ Path.DirectorySeparatorChar });
    Console.WriteLine(parts[parts.Length - 1]);
