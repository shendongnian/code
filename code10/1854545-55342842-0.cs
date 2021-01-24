    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace AltostratusEventsTests
    {
        // https://stackoverflow.com/questions/55043372/testing-azure-blob-storage-using-azurite
        public class AzuriteBlobEmulator : IDisposable
        {
            private Process _blobProcess;
    
            public AzuriteBlobEmulator()
            {
                StartEmulator();
            }
    
            public void Dispose()
            {
                StopEmulator();
            }
    
            private void StartEmulator()
            {
                _blobProcess = new Process();
                _blobProcess.StartInfo.FileName = BlobDotExePath();
                _blobProcess.StartInfo.Arguments = BlobDotExeArgs();
                _blobProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                _blobProcess.Start();
            }
    
            private void StopEmulator()
            {
                try
                {
                    _blobProcess.Kill();
                    _blobProcess.WaitForExit();
                }
                catch
                {
    
                }
            }
    
            private string BlobDotExePath()
            {
                var blobPath = Environment.GetEnvironmentVariable("BLOB_EXE");
                if (string.IsNullOrEmpty(blobPath))
                {
                    throw new NotSupportedException(@"
    
    The BLOB_EXE environment variable must be set to the location of the azurite blob emulator.  
    This can be done by running InstallBlobExe.bat
    
    ");
                }
                return blobPath;
            }
    
            private string BlobDotExeArgs()
            {
                return "-l " + Directory.GetCurrentDirectory();
            }
        }
    }
