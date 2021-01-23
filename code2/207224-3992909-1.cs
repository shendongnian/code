    public class MyAudioWrapper
    {
       [DllImport("winmm.dll", EntryPoint = "waveOutGetVolume")]
       public extern void GetWaveVolume(IntPtr devicehandle, out int Volume);
    
       ...
    }
