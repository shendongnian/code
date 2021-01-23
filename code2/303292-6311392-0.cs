    const int chunkSize = 2 * 1024; // 2KB
    var inputFiles = new[] { "file1.dat", "file2.dat", "file3.dat" };
    using (var output = File.Create("output.dat"))
    {
        foreach (var file in inputFiles)
        {
            using (var input = File.OpenRead(file))
            {
                var buffer = new byte[chunkSize];
                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var actual = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
                    output.Write(actual, 0, actual.Length);
                }
            }
        }
    }
