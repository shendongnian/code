    public interface IVideoSource : IGenericSampleCB
    {
        double PercentageCompleted { get; }
        int GetImage(int iFrameNumber, IntPtr ip, int iSize, out int iRead);
        void SetMediaType(global::IPerform.Video.Conversion.Interops.IGenericSampleConfig psc);
        int SetTimeStamps(global::DirectShowLib.IMediaSample pSample, int iFrameNumber);
    }
