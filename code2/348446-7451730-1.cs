    string filepath = "c:\windows\test.exe";
    bool bOk = false;
    try
    {
      bOk = System.IO.File.Exists("filepath");
    }
    catch (Exception ex)
    {
          Console.WriteLine(ex.Message);
     }
    if (!bOk)
    {
        Console.WriteLine("Error: Invalid Path");
    }
    else
    {
       Process p = new Process();
        p.StartInfo.FileName = "filepath";
        p.StartInfo.Arguments = "/c dir *.cs";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        Console.WriteLine("Output:");
        Console.WriteLine(output);    
    }
