    var semaphore = new SemaphoreSlim(1000);
    var tasks = Directory.GetFiles(@"D:\FilesToUpload")
        .Select(async filePath =>
        {
            var fi = new FileInfo(filePath);
            var weight = (int)Math.Min(1000, fi.Length / 1_000_000);
            await semaphore.WaitAsync(weight); // Imaginary overload that accepts weight
            try
            {
                await cloudService.UploadFile(filePath);
            }
            finally
            {
                semaphore.Release(weight);
            }
        })
        .ToArray();
    await Task.WhenAll(tasks);
