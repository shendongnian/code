        public void PlayInAllAvailableDevices(string fileName)
        {
            int waveOutDevices = WaveOut.DeviceCount;
            for (int n = 0; n < waveOutDevices; n++)
            {
                PlaySoundInDevice(n, fileName);
            }
        }
