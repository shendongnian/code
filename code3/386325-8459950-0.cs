    public static string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
        static void Main(string[] args)
        {
            JintEngine engine = new JintEngine();
            engine.SetFunction("ReadFile", new Func<string, string[]>(ReadLines));
            DirectoryInfo di = new DirectoryInfo("."); // Current path
            engine.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, di.FullName)); // Add All-access permission for the cwd. (including sub-directories)
            // Alternatively:
            // engine.DisableSecurity(); // The brutal and insecure way, you should not use this unless there is no other option.
            engine.Run(@"
                var lines = ReadFile('test.txt');
                print ('I got ' + lines.length + ' lines.');
            ");
            
        }
