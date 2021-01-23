    [DllImport("HELLO.dll", CharSet = CharSet.Unicode)]
    public static extern void Test();
    
    static void Main()
    {
         string currentWorkingDirectory = Directory.GetCurrentDirectory();
         Console.WriteLine(currentWorkingDirectory);
         Directory.SetCurrentDirectory("E:\\foobar");
         currentWorkingDirectory = Directory.GetCurrentDirectory();
         Console.WriteLine(currentWorkingDirectory);
         // Call method in DLL we know doesn't exist.
         Test();
    }
