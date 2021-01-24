    Uri uri = new Uri("http://localhost:1000");
    BasicHttpBinding binding = new BasicHttpBinding();
    ServiceHost sh = null;
    
    protected override void OnStart(string[] args)
    {
        sh = new ServiceHost(typeof(MyService), uri);
        ServiceMetadataBehavior smb;
        smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (smb==null)
        {
            smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };
            sh.Description.Behaviors.Add(smb);
        }
        sh.Open();
        WriteLog($"Service is ready at {DateTime.Now.ToString("hh-mm-ss")}");
    }
    
    protected override void OnStop()
    {
        if (sh!=null&&sh.State==CommunicationState.Opened)
        {
            sh.Close();
            WriteLog($"Service is closed at {DateTime.Now.ToString("hh-mm-ss")}");
        }
    }
    public static void WriteLog(string text)
    {
        using (StreamWriter sw=File.AppendText(@"D:\log.txt"))
        {
            sw.WriteLine(text);
            sw.Flush();
        }
    }
