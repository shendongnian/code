    public static void Main()
    {
       var p = new Process();  
       p.StartInfo.UseShellExecute = false;  
       p.StartInfo.RedirectStandardError = true;  
       p.StartInfo.FileName = "Write500Lines.exe";  
       p.Start();  
       // To avoid deadlocks, always read the output stream first and then wait.  
       string output = p.StandardError.ReadToEnd();  
       p.WaitForExit();
       Console.WriteLine($"\nError stream: {output}");
    }
