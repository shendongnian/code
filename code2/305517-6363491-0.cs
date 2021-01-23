    class Program
    {
        [Flags]
        enum MoveFileFlags
        {
            None = 0,
            ReplaceExisting = 1,
            CopyAllowed = 2,
            DelayUntilReboot = 4,
            WriteThrough = 8,
            CreateHardlink = 16,
            FailIfNotTrackable = 32,
        }
    
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool MoveFileEx(
            string lpExistingFileName,
            string lpNewFileName,
            MoveFileFlags dwFlags
        );
    
        static void Main()
        {
            string lockFile = "foo.dat";
            if (!File.Exists(lockFile))
            {
                // that's a first run after the reboot => create the file
                File.WriteAllText(lockFile, "");
                // Mark the file for deletion after reboot
                MoveFileEx(lockFile, null, MoveFileFlags.DelayUntilReboot);
                Console.WriteLine("it's a first run");
            }
            else
            {
                // that's a consecutive run
                Console.WriteLine("it's a consecutive run");
            }
        }
    }
