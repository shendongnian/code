    private void Callback(IntPtr waveInHandle, WaveInterop.WaveMessage message, IntPtr userData, WaveHeader waveHeader, IntPtr reserved)
    {
        if (message == WaveInterop.WaveMessage.WaveInData)
        {
    	GCHandle hBuffer = (GCHandle)waveHeader.userData;
    	WaveInBuffer buffer = (WaveInBuffer)hBuffer.Target;
	if (buffer != null)
	{
	    if (DataAvailable != null)
	    {
		DataAvailable(this, new WaveInEventArgs(buffer.Data, buffer.BytesRecorded));
	    }
	    if (recording)
	    {
		buffer.Reuse();
	    }
	}
	else
	{
	    if (RecordingStopped != null)
	    {
		RecordingStopped(this, EventArgs.Empty);
	    }
	}
    }
}
