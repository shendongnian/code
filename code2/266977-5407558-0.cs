    Action<DirectoryInfo> size = null;
    var sizes = new Dictionary<string, long>();
    size = di =>
                {
                    foreach (var d in di.GetDirectories())
                    {
                        size(d);
                    }
                    sizes.Add(di.FullName, di.GetFiles().Sum(f => f.Length));
                };
    size(new DirectoryInfo("C:\\"));
