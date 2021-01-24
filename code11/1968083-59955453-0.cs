    capture.DataAvailable += (s, a) =>
    {
        writer.Write(a.Buffer, 0, a.BytesRecorded);
        if (writer.Position > capture.WaveFormat.AverageBytesPerSecond * 20)
        {
            capture.StopRecording();
        }
    };
