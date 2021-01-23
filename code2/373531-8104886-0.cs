    //don't know which one is good to use 
            job.AcquireCredentials += new EventHandler<AcquireCredentialsEventArgs>(job_AcquireCredentials);
            _myUserName = "indes";
            _pw = PullPW("indes");              
            Uri url = new Uri("http://192.168.1.74:8080/live");
            PushBroadcastPublishFormat pubpoint = new PushBroadcastPublishFormat();
            pubpoint.PublishingPoint = url;
            pubpoint.UserName = _myUserName;
            pubpoint.Password = _pw;
