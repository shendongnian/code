    private void initProcess()
    {
        processInfo = new ProcessStartInfo("cmd.exe", "/C " + command);
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardInput = true;
        processInfo.RedirectStandardOutput = true;
        processInfo.WindowStyle = ProcessWindowStyle.Normal;
        process = new Process();
        process.StartInfo = processInfo;
        //process.Exited += new EventHandler(process_Exited); // Actually no longer required, since HasExited will test for it
        // return; // return not required
    }
    // No longer need Exited, since HasExited checks for it
    /*
    void process_Exited(object sender, EventArgs e)
    {
        Console.WriteLine("Into process_Exited....");
        processInfo = null;
        if (process != null)
        {
            sw = null;
            // Do not close here. Closing here will prevent "process.WaitForExit()" and "process.HasExited" from working
            //process.Close();
            //process = null;
        }
    }
    */
    public bool StartOpenVPN()
    {
        bool installed = false;
        try
        {
            Console.WriteLine("Command = " + command);
            Console.WriteLine("Opening cmd");
            initProcess();
            process.Start();
            sw = process.StandardInput;
            Console.WriteLine("Has Exited after SW = " + process.HasExited.ToString()); // RETURS FALSE BUT GOES TO process_Exited & for next line results is NullPointerException
            sw.WriteLine("foo");
            sw.WriteLine("*baa");
             //sw.Flush();
            //sw.Close();
            //process.BeginOutputReadLine();
            //process.OutputDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
             while (process.HasExited == false)
             {
                 string d = process.StandardOutput.ReadLine();
                 Console.WriteLine("Line = " + d);
             }
            // process.WaitForExit(); // Not required, since HasExited already check whether process has exited
            // Added here from Exited, so that it only close after exit
            process.Close();
            process = null;
            Console.WriteLine("Finished cmd");
        }
        catch (Exception e)
        {
            Console.WriteLine("Errror Opening : " + e.Message);
            Console.WriteLine(e.StackTrace);
        }
        return installed;
    }
