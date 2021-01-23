    using System.Diagnostics;
    using Microsoft.Win32;
    
    namespace ProgramLauncher
    {
        class Program
        {
            // change the following constants as needed
            const string PROGRAM_NAME = @"notepad.exe";
            const string REPLACEMENT_PATH = @"C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.EXE";
            const string RUNNING_PATH = @"C:\Windows\notepad.exe";
    
            // root key
            const string KEY = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";
    
            static void Main(string[] args)
            {
                using (var rootKey = Registry.LocalMachine.OpenSubKey(KEY, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    string oldPath = default(string);
                    try
                    {
                        oldPath = BackupKey(rootKey, PROGRAM_NAME, REPLACEMENT_PATH);
                        Process.Start(RUNNING_PATH).WaitForExit();
                    }
                    finally
                    {
                        RestoreKey(rootKey, PROGRAM_NAME, oldPath);
                    }
                }
            }
    
            static string BackupKey(RegistryKey rootKey, string programName, string newPath)
            {
                Debug.Assert(rootKey != null);
                Debug.Assert(!string.IsNullOrEmpty(programName));
                Debug.Assert(!string.IsNullOrEmpty(newPath) && System.IO.File.Exists(newPath));
                using (var programKey = rootKey.CreateSubKey(programName, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    var oldDebugger = programKey.GetValue("Debugger") as string;
                    if (newPath.Contains(" "))
                        newPath = "\"" + newPath + "\"";
                    programKey.SetValue("Debugger", newPath, RegistryValueKind.String);
                    return oldDebugger;
                }
            }
    
            static void RestoreKey(RegistryKey rootKey, string programName, string oldPath)
            {
                Debug.Assert(rootKey != null);
                Debug.Assert(!string.IsNullOrEmpty(programName));
                if (oldPath != null)
                {
                    using (var programKey = rootKey.OpenSubKey(programName, RegistryKeyPermissionCheck.ReadWriteSubTree))
                        programKey.SetValue("Debugger", oldPath);
                }
                else
                {
                    rootKey.DeleteSubKey(programName);
                }
            }
        }
    }
