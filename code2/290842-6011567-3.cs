        private void DisposeAll()
        {
            foreach (var playbackSession in outputDevices.Values)
            {
                playbackSession.WaveOut.Dispose();
                playbackSession.WaveStream.Dispose();
            }
        }
