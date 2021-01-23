    byte[] CreateWaveFileHeader(int SizeOfData, short ChannelCount, uint SamplesPerSecond, short BitsPerSample)
    {
    
        short BlockAlign = (short)(ChannelCount * (BitsPerSample / 8));
        uint AverageBytesPerSecond = SamplesPerSecond * BlockAlign;
    
        List<byte> pom = new List<byte>();
        pom.AddRange(ASCIIEncoding.ASCII.GetBytes("RIFF"));
        pom.AddRange(BitConverter.GetBytes(SizeOfData + 36)); //Size + up to data
        pom.AddRange(ASCIIEncoding.ASCII.GetBytes("WAVEfmt "));
        pom.AddRange(BitConverter.GetBytes(((uint)16))); //16 For PCM
        pom.AddRange(BitConverter.GetBytes(((short)1))); //PCM FMT
        pom.AddRange(BitConverter.GetBytes(((short)ChannelCount)));
        pom.AddRange(BitConverter.GetBytes((uint)SamplesPerSecond));
        pom.AddRange(BitConverter.GetBytes((uint)AverageBytesPerSecond));
        pom.AddRange(BitConverter.GetBytes((short)BlockAlign));
        pom.AddRange(BitConverter.GetBytes((short)BitsPerSample));
        pom.AddRange(ASCIIEncoding.ASCII.GetBytes("data"));
        pom.AddRange(BitConverter.GetBytes(SizeOfData));
    
        return pom.ToArray();
    }
