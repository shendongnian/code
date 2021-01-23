    using (BinaryReader br = new BinaryReader(File.OpenRead("sample.vox")))
    {
        IntPtr format = AudioCompressionManager.GetPcmFormat(1, 16, 8000);
        using (WaveWriter ww = new WaveWriter(new MemoryStream(), 
            AudioCompressionManager.FormatBytes(format)))
        {
            Vox.Vox2Wav(br, ww);
        }
    }
