    using (var input = File.OpenRead(@"testblob.txt")) //5000000 bytes
    using (var output = blob.OpenWrite())
    {
        input.CopyTo(output);
    }
