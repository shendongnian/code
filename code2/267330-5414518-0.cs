    public class CreateFileOrFolder
    {
        static void Main()
        {
            string activeDir = @"\\COMPUTER";
            string newPath = System.IO.Path.Combine(activeDir, "myNewFolder");
    
            System.IO.Directory.CreateDirectory(newPath);
        }
    }
