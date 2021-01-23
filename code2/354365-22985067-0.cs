        static void OggToWavWithOgg()
        {
            string fileName = @"e:\Down\fortuna.ogg";
            using (DsReader dr = new DsReader(fileName))
            {
                if (dr.HasAudio)
                {
                    short oggFormatTag = 26479;
                    IntPtr format = dr.ReadFormat();
                    WaveFormat waveFormat = AudioCompressionManager.GetWaveFormat(format);
                    IntPtr formatOgg = AudioCompressionManager.GetCompatibleFormat(format, oggFormatTag);
                    using (WaveWriter ww = new WaveWriter(File.Create(fileName + ".wav"),
                        AudioCompressionManager.FormatBytes(formatOgg)))
                    {
                        AudioCompressionManager.Convert(dr, ww, true);
                    }
                }
            }
        }
