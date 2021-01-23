    class Foo
    {
        public static void Main()
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "pdftotext";
            p1.StartInfo.Arguments = "test.pdf test.txt";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.WorkingDirectory = @"C:\";
            
            p1.Start();
            p1.WaitForExit();
        }
    }
