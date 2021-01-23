    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32.SafeHandles;
    namespace Example
    {
      public static class DuplicatedHandleExample
      {
        [DllImport("kernel32.dll")]
        private static extern bool DuplicateHandle(
          SafeFileHandle hSourceProcessHandle,
          IntPtr hSourceHandle,
          SafeFileHandle hTargetProcessHandle,
          out SafeFileHandle lpTargetHandle,
          UInt32 dwDesiredAccess,
          bool bInheritHandle,
          UInt32 dwOptions);
        [DllImport("kernel32.dll")]
        private static extern SafeFileHandle OpenProcess(
          UInt32 dwDesiredAccess,
          bool bInheritHandle,
          int dwProcessId);
        private const UInt32 PROCESS_DUP_HANDLE = 0x0040;
        private const UInt32 DUPLICATE_SAME_ACCESS = 0x0002;
        public static void CreateFileInProcessA()
        {
          try
          {
            // open new temp file with FileOptions.DeleteOnClose
            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("D"));
            using (FileStream fs = new FileStream(tempFilePath, FileMode.CreateNew,
              FileAccess.ReadWrite, FileShare.Read | FileShare.Write | FileShare.Delete,
              4096, FileOptions.DeleteOnClose))
            {
              // put a message in the temp file
              fs.Write(new[] { (byte)'h', (byte)'i', (byte)'!' }, 0, 3);
              fs.Flush();
              // put our process ID and file handle on clipboard
              string data = string.Join(",",
                Process.GetCurrentProcess().Id.ToString(),
                fs.SafeFileHandle.DangerousGetHandle().ToString());
              Clipboard.SetData(DataFormats.UnicodeText, data);
              // show messagebox (while holding file open!) and wait for user to click OK
              MessageBox.Show("Temp File opened. Process ID and File Handle copied to clipboard. Click OK to close temp file.");
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        }
        public static void OpenFileInProcessB()
        {
          try
          {
            // get process ID and file handle from clipboard
            string data = (string)Clipboard.GetData(DataFormats.UnicodeText);
            string[] dataParts = data.Split(',');
            int sourceProcessId = int.Parse(dataParts[0]);
            IntPtr sourceFileHandle = new IntPtr(Int64.Parse(dataParts[1]));
            // get handle to target process
            using (SafeFileHandle sourceProcessHandle =
              OpenProcess(PROCESS_DUP_HANDLE, false, sourceProcessId))
            {
              // get handle to our process
              using (SafeFileHandle destinationProcessHandle =
                OpenProcess(PROCESS_DUP_HANDLE, false, Process.GetCurrentProcess().Id))
              {
                // duplicate handle into our process
                SafeFileHandle destinationFileHandle;
                DuplicateHandle(sourceProcessHandle, sourceFileHandle,
                  destinationProcessHandle, out destinationFileHandle,
                  0, false, DUPLICATE_SAME_ACCESS);
                using (destinationFileHandle)
                {
                  // get a FileStream wrapper around it
                  using (FileStream fs = new FileStream(destinationFileHandle, FileAccess.ReadWrite, 4096))
                  {
                    // read file contents
                    fs.Position = 0;
                    byte[] buffer = new byte[100];
                    int numBytes = fs.Read(buffer, 0, 100);
                    string message = Encoding.ASCII.GetString(buffer, 0, numBytes);
                    // show messagebox (while holding file open!) and wait for user to click OK
                    MessageBox.Show("Found this message in file: " + message + Environment.NewLine +
                      "Click OK to close temp file");
                  }
                }
              }
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        }
      }
    }
