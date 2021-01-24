using System;
using NAudio.Wave;
using System.Diagnostics;
public class AudioRecorder
{
    public WaveInEvent MyWaveIn;
    public readonly double RecordTime;
    private WaveOutEvent _wav = new WaveOutEvent();
    private bool _isFull = false;
    private int _pos = 0;
    private byte[] _buffer;
    private bool _isRecording = false;
    /// <summary>
    /// Creates a new recorder with a buffer
    /// </summary>
    /// <param name="recordTime">Time to keep in buffer (in seconds)</param>
    public AudioRecorder(double recordTime)
    {
        RecordTime = recordTime;
        MyWaveIn = new WaveInEvent();
        MyWaveIn.DataAvailable += DataAvailable;
        _buffer = new byte[(int)(MyWaveIn.WaveFormat.AverageBytesPerSecond * RecordTime)];
    }
    /// <summary>
    /// Starts recording
    /// </summary>
    public void StartRecording()
    {
        if (!_isRecording)
        {
            try
            {
                MyWaveIn.StartRecording();
            }
            catch (InvalidOperationException)
            {
                Debug.WriteLine("Already recording!");
            }
        }
            
        _isRecording = true;
    }
    /// <summary>
    /// Stops recording
    /// </summary>
    public void StopRecording()
    {
        MyWaveIn.StopRecording();
        _isRecording = false;
    }
    /// <summary>
    /// Play currently recorded data
    /// </summary>
    public void PlayRecorded() 
    {
        if (_wav.PlaybackState == PlaybackState.Stopped)
        {
            var buff = new BufferedWaveProvider(MyWaveIn.WaveFormat);
            var bytes = GetBytesToSave();
            buff.AddSamples(bytes, 0, bytes.Length);
            _wav.Init(buff);
            _wav.Play();
        }
            
    }
    /// <summary>
    /// Stops replay
    /// </summary>
    public void StopReplay()
    {
        if (_wav != null) _wav.Stop();
    }
    /// <summary>
    /// Save to disk
    /// </summary>
    /// <param name="fileName"></param>
    public void Save(string fileName)
    {
        var writer = new WaveFileWriter(fileName, MyWaveIn.WaveFormat);
        var buff = GetBytesToSave();
        writer.Write(buff, 0 , buff.Length);
        writer.Flush();
    }
    private void DataAvailable(object sender, WaveInEventArgs e)
    {
        for (int i = 0; i < e.BytesRecorded; ++i)
        {
            // save the data
            _buffer[_pos] = e.Buffer[i];
            // move the current position (advances by 1 OR resets to zero if the length of the buffer was reached)
            _pos = (_pos + 1) % _buffer.Length;
            // flag if the buffer is full (will only set it from false to true the first time that it reaches the full length of the buffer)
            _isFull |= (_pos == 0);
        }
    }
    public byte[] GetBytesToSave()
    {
        int length = _isFull ? _buffer.Length : _pos;
        var bytesToSave = new byte[length];
        int byteCountToEnd = _isFull ? (_buffer.Length - _pos) : 0;
        if (byteCountToEnd > 0)
        {
            // bytes from the current position to the end
            Array.Copy(_buffer, _pos, bytesToSave, 0, byteCountToEnd);
        }
        if (_pos > 0)
        {
            // bytes from the start to the current position
            Array.Copy(_buffer, 0, bytesToSave, byteCountToEnd, _pos);
        }
        return bytesToSave;
    }
    /// <summary>
    /// Starts recording if WaveIn stopped
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Stopped(object sender, StoppedEventArgs e)
    {
        Debug.WriteLine("Recording stopped!");
        if (e.Exception != null) Debug.WriteLine(e.Exception.Message);
        if (_isRecording)
        {
            MyWaveIn.StartRecording();
        }
    }
}
