    static void Main(string[] args)
    {
        if (args[0] == "run")
        {
            //actually run your application here
        }
        else
        {
            //create another instance of this process
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Assembly.GetExecutingAssembly().Location;
            info.Arguments = "run";
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
    
            Process.Start(info);
        }
    }
