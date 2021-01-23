    Process process = new Process(); 
    ProcessStartInfo startInfo = new ProcessStartInfo(); 
    startInfo.FileName = MyExe; 
    startInfo.Arguments = ArgumentsForMyExe; 
    process.StartInfo = startInfo; 
    process.Start(); 
    process.WaitForExit(); // This is the line which answers my question :) 
