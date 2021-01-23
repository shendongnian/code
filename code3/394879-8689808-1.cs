    Process[] process = Process.GetProcessesByName("cmd");
    byte[] memory = new byte[255];
    uint bytesRead =0;
    bool succes = ReadProcessMemory(
                 process[0].Handle,  
                 process[0].MainModule.BaseAddress , 
                 memory , 
                 (uint) memory.Length , 
                 ref bytesRead);
