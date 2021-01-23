    var assembly = Assembly.GetExecutingAssembly();
    using (var stream = assembly.GetManifestResourceStream("ProjectName.Tests.IntegrationTests.TestData.126.txt"))
    using (var reader = new StreamReader(stream))
    {
        string text = reader.ReadToEnd();
    }
