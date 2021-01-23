    public class MyAudioWrapper
    {
       [DLLImport("winmm.dll", EntryPoint="waveOutGetVolume")]
       public extern void GetWaveVolume(IntPtr devicehandle, out int Volume);
    
       ...
    }
