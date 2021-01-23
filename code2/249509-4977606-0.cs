    ProcessStartInfo psi = new ProcessStartInfo("ruby", "/Users/smcho/Desktop/testit.rb");
    psi.RedirectStandardOuput = true;W    
    Process proc = new Process(psi);
    proc.Start();
    StreamReader stdout = proc.StandardOutput;
    string line;
    while ((line = stdout.ReadLine()) != null)
       Console.WriteLine(line);
