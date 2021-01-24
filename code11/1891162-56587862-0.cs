    Process pipeClient = new Process();
    pipeClient.StartInfo.FileName = @"Executable Location";
    using (AnonymousPipeServerStream pipeServer =
        new AnonymousPipeServerStream(PipeDirection.Out,
        HandleInheritability.Inheritable))
    {
    pipeServer.ReadMode = PipeTransmissionMode.Byte;
    // Pass the client process a handle to the server.
    pipeClient.StartInfo.Arguments =
            pipeServer.GetClientHandleAsString();
        pipeClient.StartInfo.UseShellExecute = false;
        pipeClient.Start();
        pipeServer.DisposeLocalCopyOfClientHandle();
        try
        {
        Byte[] bytes = File.ReadAllBytes(@"Location of Data File");
        string file = Convert.ToBase64String(bytes);
        // Read user input and send that to the client process.
        using (StreamWriter sw = new StreamWriter(pipeServer))
        {
            sw.Flush();
            sw.Write(file);
            pipeServer.WaitForPipeDrain();
        }
    }
        // Catch the IOException that is raised if the pipe is broken
        // or disconnected.
        catch (IOException a)
        {
        }
    }
    pipeClient.WaitForExit();
    pipeClient.Close();
