    public static void Test(){
        FileInfo inf = new FileInfo("your_file");
    
        while (inf.IsFileLocked()) {
          Console.WriteLine("File locked, wait...");
        };
    }
