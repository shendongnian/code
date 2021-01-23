    public struct WaveFormat
    {
    		
    	private short m_FormatTag;       // most often PCM = 1		
    	private short m_nChannels;       // number of channels		
    	private int m_SamplesPerSecond;  // samples per second eg 44100		
    	private int m_AvgBytesPerSecond; // bytes per second eg 176000		
    	private short m_BlockAlign;      // blockalign (byte per sample) eg 4 bytes 		
    	private short m_BitsPerSample;   // bits per sample, 8, 16, 24
    	public WaveFormat(byte BPS, int SPS, byte nChn)
    	{
    		m_FormatTag = 1;
    		//PCM
    		m_nChannels = nChn;
    		m_SamplesPerSecond = SPS;
    		m_BitsPerSample = BPS;
    		m_BlockAlign = Convert.ToInt16(m_nChannels * m_BitsPerSample / 8);
    		m_AvgBytesPerSecond = Convert.ToInt32(m_BlockAlign * m_SamplesPerSecond);
    	}
    	public short FormatTag {
    		get { return m_FormatTag; }
    		set { m_FormatTag = value; }
    	}
    	public short Channels {
    		get { return m_nChannels; }
    	}
    	public int SamplesPerSecond {
    		get { return m_SamplesPerSecond; }
    	}
    	public int AvgBytesPerSecond {
    		get { return m_AvgBytesPerSecond; }
    	}
    	public short BlockAlign {
    		get { return m_BlockAlign; }
    	}
    	public short BitsPerSample {
    		get { return m_BitsPerSample; }
    	}
    	public void Read(IO.BinaryReader br)
    	{
    		var _with1 = br;
    		m_FormatTag = _with1.ReadInt16;
    		m_nChannels = _with1.ReadInt16;
    		m_SamplesPerSecond = _with1.ReadInt32;
    		m_AvgBytesPerSecond = _with1.ReadInt32;
    		m_BlockAlign = _with1.ReadInt16;
    		m_BitsPerSample = _with1.ReadInt16;
    	}
    	public void Write(IO.BinaryWriter bw)
    	{
    		var _with2 = bw;
    		_with2.Write(m_FormatTag);
    		_with2.Write(m_nChannels);
    		_with2.Write(m_SamplesPerSecond);
    		_with2.Write(m_AvgBytesPerSecond);
    		_with2.Write(m_BlockAlign);
    		_with2.Write(m_BitsPerSample);
    	}
    }
