    private string GETCMD()
    {
        string tempGETCMD = null;
        Process CMDprocess = new Process();
        System.Diagnostics.ProcessStartInfo StartInfo = new System.Diagnostics.ProcessStartInfo();
        StartInfo.FileName = "cmd"; //starts cmd window
        StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        StartInfo.CreateNoWindow = true;
        StartInfo.RedirectStandardInput = true;
        StartInfo.RedirectStandardOutput = true;
        StartInfo.UseShellExecute = false; //required to redirect
        CMDprocess.StartInfo = StartInfo;
        CMDprocess.Start();
        System.IO.StreamReader SR = CMDprocess.StandardOutput;
        System.IO.StreamWriter SW = CMDprocess.StandardInput;
        SW.WriteLine("@echo on");
        SW.WriteLine("cd\\"); //the command you wish to run.....
        SW.WriteLine("cd C:\\Program Files");
        //insert your other commands here
        SW.WriteLine("exit"); //exits command prompt window
        tempGETCMD = SR.ReadToEnd(); //returns results of the command window
        SW.Close();
        SR.Close();
        return tempGETCMD;
    }
