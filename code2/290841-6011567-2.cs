        private void PlaySoundInDevice(int deviceNumber, string fileName)
        {
            if (outputDevices.ContainsKey(deviceNumber))
            {
                outputDevices[deviceNumber].WaveOut.Dispose();
                outputDevices[deviceNumber].WaveStream.Dispose();
            }
            var waveOut = new WaveOut();
            waveOut.DeviceNumber = deviceNumber;
            WaveStream waveReader = new WaveFileReader(fileName);
            // hold onto the WaveOut and  WaveStream so we can dispose them later
            outputDevices[deviceNumber] = new PlaybackSession { WaveOut=waveOut, WaveStream=waveReader };
            
            waveOut.Init(waveReader);
            waveOut.Play();
        }
        private Dictionary<int, PlaybackSession> outputDevices = new Dictionary<int, PlaybackSession>();
        class PlaybackSession
        {
            public IWavePlayer WaveOut { get; set; }
            public WaveStream WaveStream { get; set; }
        }
