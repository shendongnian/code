    ProcessStartInfo procInfo = new ProcessStartInfo(@"C:\a\a.exe");
    procInfo.CreateNoWindow = true;
    
    List<string> arguments = new List<string>();
    arguments.Add("01");
    arguments.Add(user_number);
    arguments.Add(email);
    
    procInfo.Arguments = string.Join(" ", arguments);
    Process.Start(procInfo);
