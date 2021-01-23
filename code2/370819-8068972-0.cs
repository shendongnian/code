 static void Main(string[] args)
        {            
            EncoderDevice video = EncoderDevices.FindDevices(EncoderDeviceType.Video).Count > 0 ? EncoderDevices.FindDevices(EncoderDeviceType.Video)[0] : null;
            EncoderDevice audio = EncoderDevices.FindDevices(EncoderDeviceType.Audio).Count > 0 ? EncoderDevices.FindDevices(EncoderDeviceType.Audio)[0] : null;
            LiveJob job = new LiveJob();
            job.AcquireCredentials += new EventHandler<AcquireCredentialsEventArgs>(job_AcquireCredentials);
            if (video != null && audio != null)
            {
                LiveDeviceSource source = job.AddDeviceSource(video, audio);
                job.ActivateSource(source);
                PushBroadcastPublishFormat publishingPoint = new PushBroadcastPublishFormat();
                publishingPoint.PublishingPoint = new Uri("http://streamwebtown.com/abc");
                WindowsMediaOutputFormat wmof = new WindowsMediaOutputFormat();
                VideoProfile vProfile = new AdvancedVC1VideoProfile();
                AudioProfile aProfile = new WmaAudioProfile();
                wmof.VideoProfile = vProfile;
                wmof.AudioProfile = aProfile;
                job.ApplyPreset(LivePresets.VC1Broadband16x9);
                job.PublishFormats.Add(publishingPoint);
                job.OutputFormat = wmof;
                job.PreConnectPublishingPoint();
                job.StartEncoding();
                //After finished encoding dispose of all objects.
                Console.ReadKey();
                job.StopEncoding();
                job.Dispose();
                video.Dispose();
                audio.Dispose();
                source.Dispose();
            }
        }
        static void job_AcquireCredentials(object sender, AcquireCredentialsEventArgs e)
        {
            e.UserName = "user";
            e.Password = PullPW("Stream");
            e.Modes = AcquireCredentialModes.None;
        }
        private static SecureString PullPW(string pw)
        {
            SecureString s = new SecureString();
            foreach (char c in pw) s.AppendChar(c);
            return s;
        }
</pre>
