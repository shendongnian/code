    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static async Task Main()
            {
                string file = @"C:\ISO\063-2495-00-Rev 1.iso";
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < 4; ++i) // Try several times.
                {
                    sw.Restart();
                    var hash = await ComputeMd5Async(file);
                    Console.WriteLine("ComputeMd5Async() Took " + sw.Elapsed);
                    Console.WriteLine(string.Join(", ", hash));
                    Console.WriteLine();
                    sw.Restart();
                    hash = ComputeMd5(file);
                    Console.WriteLine("ComputeMd5() Took " + sw.Elapsed);
                    Console.WriteLine(string.Join(", ", hash));
                    Console.WriteLine();
                }
            }
            public static byte[] ComputeMd5(string filename)
            {
                using var md5    = MD5.Create();
                using var stream = File.OpenRead(filename);
                md5.ComputeHash(stream);
                return md5.Hash;
            }
            public static async Task<byte[]> ComputeMd5Async(string filename)
            {
                using (var md5  = MD5.Create())
                using (var file = File.OpenRead(filename))
                {
                    const int BUFFER_SIZE = 4 * 1024 * 1024; // Adjust buffer size to taste.
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
        }
    }
