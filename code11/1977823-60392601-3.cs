    public static async Task<byte[]> ComputeMd5Async(string filename)
    {
        using (var md5  = MD5.Create())
        using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 16384, FileOptions.SequentialScan | FileOptions.Asynchronous))
        {
            const int BUFFER_SIZE = 16 * 1024 * 1024; // Adjust buffer size to taste.
            byte[] buffer1 = new byte[BUFFER_SIZE];
            byte[] buffer2 = new byte[BUFFER_SIZE];
            byte[] buffer  = buffer1; // Double-buffered, so use 'buffer' to switch between buffers.
            var task = Task.CompletedTask;
            while (true)
            {
                buffer = (buffer == buffer1) ? buffer2 : buffer1; // Swap buffers for double-buffering.
                int n = await file.ReadAsync(buffer, 0, buffer.Length);
                await task;
                task.Dispose();
                if (n == 0)
                    break;
                var block = buffer;
                task = Task.Run(() => md5.TransformBlock(block, 0, n, null, 0));
            }
            md5.TransformFinalBlock(buffer, 0, 0);
            return md5.Hash;
        }
    }
