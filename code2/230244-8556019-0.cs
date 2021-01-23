        public void CaptureAudio()
        {
            using (var source = new SoundCardSource())
            {
                source.SampleRateKHz = 44.1;
                source.SampleDataReady += this.OnSampleDataReady;
                source.Start();
                // Capture 5 seconds of audio...
                Thread.Sleep(5000);
                source.Stop();
            }
        }
        private void OnSampleDataReady(object sender, SampleDataEventArgs e)
        {
            // Do something with e.Data short array on separate thread...
        }
