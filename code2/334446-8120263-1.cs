    GCHandle hBuffer = (GCHandle)waveHeader.userData;
    WaveInBuffer buffer = (WaveInBuffer)hBuffer.Target;
    if (buffer == null)
    {
       return; // with this new line, everything works fine
    }
    if (DataAvailable != null)
    {
       DataAvailable(this, new WaveInEventArgs(buffer.Data, buffer.BytesRecorded));
    }
    if (recording)
    {
       buffer.Reuse();
    }
    else
    {
       if (RecordingStopped != null)
       {
          RecordingStopped(this, EventArgs.Empty);
       }
    }
