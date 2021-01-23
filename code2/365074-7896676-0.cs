    var find = new Process();
    var psi = find.StartInfo;
    psi.FileName = "find.exe";
    psi.UseShellExecute = false;
    psi.RedirectStandardError = true;
    psi.RedirectStandardOutput = true;
    // remember to quote the search string argument
    psi.Arguments = "\"quick\" xyzzy.txt";
    
    find.Start();
    
    string rslt = find.StandardOutput.ReadToEnd();
    
    find.WaitForExit();
    
    Console.WriteLine("Result = {0}", rslt);
    
    Console.WriteLine();
    Console.Write("Press Enter:");
    Console.ReadLine();
    return 0;
