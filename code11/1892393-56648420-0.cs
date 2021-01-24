    public static NetSuite.File GetFileById(this NetSuiteService ns, int fileId)
    {
        var file = new NetSuite.File();
        var response = ns.get(new RecordRef()
        {
            type = RecordType.file,
            internalId = fileId.ToString(),
            typeSpecified = true
        });
        if (response.status.isSuccess)
        {
            file = response.record as File;
        }
        return file;
    }
    var f = ns.GetFileById(3946);
    var path = Path.Combine(Directory.GetCurrentDirectory(), f.name);
    var contents = f.content;
    System.IO.File.WriteAllBytes(path, contents);
    Console.WriteLine($"Downloaded {f.name}");
