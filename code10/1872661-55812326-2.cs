    static string ReadResource(string fileName)
    {
        var assembly = typeof(Program).Assembly;
        var resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(f => f.Contains(fileName));
        if (!string.IsNullOrEmpty(resourceName))
        {
            using (var s = new StreamReader(assembly .GetManifestResourceStream(resourceName)))
            {
                return s.ReadToEnd();
            }
        }
        else
        {
            throw new InvalidOperationException(
                $"Unable to find resource {fileName} in {typeof(Program).Assembly}");
        }
    }
