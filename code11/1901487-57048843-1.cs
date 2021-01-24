    namespace DataMovementSamples
    {
        using System;
    #if !DOTNET5_4
    #endif
        using System.Threading.Tasks;
        using Microsoft.Azure.Storage.DataMovement;
    
        public class Program
        {
            public static async Task Main(string[] args)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Data movement directory copy sample.");
                    await BlobDirectoryCopySample();
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine("Cleanup generated data.");
                }
            }
    
            private static async Task BlobDirectoryCopySample()
            {
                var sourceBlobDir = await Util.GetCloudBlobDirectoryAsync("sourcecontainer", "dir1");
                var destBlobDir = await Util.GetCloudBlobDirectoryAsync("targetcontainer", "dir2");
    
                var options = new CopyDirectoryOptions()
                {
                    Recursive = true,
                };
    
                var context = new DirectoryTransferContext();
                context.FileTransferred += FileTransferredCallback;
                context.FileFailed += FileFailedCallback;
                context.FileSkipped += FileSkippedCallback;
    
                TransferManager.Configurations.ParallelOperations = 50;
                Console.WriteLine("Transfer started");
    
                try
                {
                    Task task = TransferManager.CopyDirectoryAsync(sourceBlobDir, destBlobDir, false, options, context);
                    await task;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The transfer is cancelled: {0}", e.Message);
                }
    
                Console.WriteLine("The transfer is completed.");
            }
    
            private static void FileTransferredCallback(object sender, TransferEventArgs e)
            {
                Console.WriteLine("Transfer Succeeds. {0} -> {1}.", e.Source, e.Destination);
            }
    
            private static void FileFailedCallback(object sender, TransferEventArgs e)
            {
                Console.WriteLine("Transfer fails. {0} -> {1}. Error message:{2}", e.Source, e.Destination, e.Exception.Message);
            }
    
            private static void FileSkippedCallback(object sender, TransferEventArgs e)
            {
                Console.WriteLine("Transfer skips. {0} -> {1}.", e.Source, e.Destination);
            }
        }
    }
