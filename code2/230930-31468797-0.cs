    var myProcess = Process.GetCurrentProcess();
    StreamReader reader = myProcess.StandardOutput;
    
    char[] buffer = new char[4096];
    byte[] data;
    int read;
    
    while (!myProcess.HasExited)
    {
        read = await reader.ReadAsync(buffer, 0, 4096);
        data = Server.ClientEncoding.GetBytes(buffer, 0, read);
        
    	await this.clientStream.WriteAsync(data, 0, data.Length);
    }
