            private void broadcastSourceFileToMediaServer2()
        {
            LiveJob job = new LiveJob();
            String filetoencode = @"c:\temp\niceday.wmv";
            LiveFileSource filesource = job.AddFileSource(filetoencode);
            filesource.PlaybackMode = FileSourcePlaybackMode.Loop;
            job.ActivateSource(filesource);
            job.ApplyPreset(LivePresets.VC1Broadband4x3);
            //don't know which one is good to use 
            job.AcquireCredentials += new EventHandler<AcquireCredentialsEventArgs>(job_AcquireCredentials);
            _myUserName = "indes";
            _pw = PullPW("indes");              
            Uri url = new Uri("http://192.168.1.74:8080/live");
            PushBroadcastPublishFormat pubpoint = new PushBroadcastPublishFormat();
            pubpoint.PublishingPoint = url;
            pubpoint.UserName = _myUserName;
            pubpoint.Password = _pw;
            job.PublishFormats.Add(pubpoint);       
            job.PreConnectPublishingPoint();
            job.StartEncoding();
            statusBox.Text = job.NumberOfEncodedSamples.ToString();
}
        public static string _myUserName { get; set; }
        public static SecureString _pw { get; set; }
        //codificação de Password a enviar
        private static SecureString PullPW(string pw)
        {
            SecureString s = new SecureString();
            foreach (char c in pw) s.AppendChar(c);
            return s;
        }
        static void job_AcquireCredentials(object sender, AcquireCredentialsEventArgs e)
        {
            e.UserName = _myUserName;
            e.Password = _pw;
            e.Modes = AcquireCredentialModes.None;
        }
