    static void Main(string[] args) {
        ProcessDir(@"c:\test");
    }
    static void ProcessDir(string currentPath) {
        foreach (var file in Directory.GetFiles(currentPath, "*.txt")) {
            // Process each file (replace this with your code / function call /
            // change signature to allow a delegate to be passed in... etc
            // StreamReader reader1 = File.OpenText(file);  // etc
            Console.WriteLine("File: {0}", file);
        }
        // recurse (may not be necessary), call each subfolder to see 
        // if there's more hiding below
        foreach (var subFolder in Directory.GetDirectories(currentPath)) {
            ProcessDir(subFolder);
        }
    }
