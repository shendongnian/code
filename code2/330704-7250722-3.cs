        internal class RawVideoSource : ImageVideoSource
    { 
        private byte[] buffer;
        private byte[] demosaicBuffer;
        private RawVideoReader reader;
        public override double PercentageCompleted
        {
            get;
            protected set;
        }
        public RawVideoSource(string sourceFile)
        {
            reader = new RawVideoReader(sourceFile);
        }
        override public void SetMediaType(IGenericSampleConfig psc)
        {
            BitmapInfoHeader bmi = new BitmapInfoHeader();
            bmi.Size = Marshal.SizeOf(typeof(BitmapInfoHeader));
            bmi.Width = reader.Header.VideoSize.Width;
            bmi.Height = reader.Header.VideoSize.Height;
            bmi.Planes = 1;
            bmi.BitCount = 24;
            bmi.Compression = 0;
            bmi.ImageSize = (bmi.BitCount / 8) * bmi.Width * bmi.Height;
            bmi.XPelsPerMeter = 0;
            bmi.YPelsPerMeter = 0;
            bmi.ClrUsed = 0;
            bmi.ClrImportant = 0;
            int hr = psc.SetMediaTypeFromBitmap(bmi, 0);
            buffer = new byte[reader.Header.FrameSize];
            demosaicBuffer = new byte[reader.Header.FrameSize * 3];
            DsError.ThrowExceptionForHR(hr);
        }
        long startFrameTime;
        long endFrameTime;
        unsafe override public int GetImage(int iFrameNumber, IntPtr ip, int iSize, out int iRead)
        {
            int hr = 0;
            if (iFrameNumber < reader.Header.NumberOfFrames)
            {
                reader.ReadFrame(buffer, iFrameNumber, out startFrameTime, out endFrameTime);
                Demosaic.DemosaicGBGR24Bilinear(buffer, demosaicBuffer, reader.Header.VideoSize);
                Marshal.Copy(demosaicBuffer, 0, ip, reader.Header.FrameSize * 3);
                PercentageCompleted = ((double)iFrameNumber / reader.Header.NumberOfFrames) * 100.0;
            }
            else
            {
                PercentageCompleted = 100;
                hr = 1; // End of stream
            }
            
            iRead = iSize;
            return hr;
        }
        override public int SetTimeStamps(IMediaSample pSample, int iFrameNumber)
        {
            reader.ReadTimeStamps(iFrameNumber, out startFrameTime, out endFrameTime);
            
            DsLong rtStart = new DsLong(startFrameTime);
            DsLong rtStop = new DsLong(endFrameTime);
            int hr = pSample.SetTime(rtStart, rtStop);
            return hr;
        }
    }
