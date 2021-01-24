.
.
.
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    //First waiting for ReadOperations to Timeout and then check Process to Timeout
    if (!outputWaitHandle.WaitOne(ProcessTimeOutMiliseconds) && !errorWaitHandle.WaitOne(ProcessTimeOutMiliseconds)
        && !process.WaitForExit(ProcessTimeOutMiliseconds)  )
    {
        //To cancel the Read operation if the process is stil reading after the timeout this will prevent ObjectDisposeException
        process.CancelOutputRead();
        process.CancelErrorRead();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Timed Out");
        Logs = output + Environment.NewLine + error;
       //To release allocated resource for the Process
        process.Close();
        return  (false, logs);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Completed On Time");
    Logs = output + Environment.NewLine + error;
    ExitCode = process.ExitCode.ToString();
    // Close frees the memory allocated to the exited process
    process.Close();
    //ExitCode now accessible
    return process.ExitCode == 0 ? (true, logs) : (false, logs);
    }
}
finally{}
