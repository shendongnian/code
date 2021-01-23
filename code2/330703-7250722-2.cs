        // A generic class to support easily changing between my different sources of data.
    // Note: You DON'T have to use this class, or anything like it.  The key is the SampleCallback
    // routine.  How/where you get your bitmaps is ENTIRELY up to you.  Having SampleCallback call
    // members of this class was just the approach I used to isolate the data handling.
    public abstract class ImageVideoSource : IDisposable, IVideoSource
    {
        #region Definitions
        /// <summary>
        /// 100 ns - used by a number of DS methods
        /// </summary>
        private const long UNIT = 10000000;
        #endregion
        /// <summary>
        /// Number of callbacks that returned a positive result
        /// </summary>
        private int m_iFrameNumber = 0;
        virtual public void Dispose()
        {
        }
        public abstract double PercentageCompleted { get; protected set; }
        abstract public void SetMediaType(IGenericSampleConfig psc);
        abstract public int GetImage(int iFrameNumber, IntPtr ip, int iSize, out int iRead);
        virtual public int SetTimeStamps(IMediaSample pSample, int iFrameNumber)
        {
            return 0;
        }
        /// <summary>
        /// Called by the GenericSampleSourceFilter.  This routine populates the MediaSample.
        /// </summary>
        /// <param name="pSample">Pointer to a sample</param>
        /// <returns>0 = success, 1 = end of stream, negative values for errors</returns>
        virtual public int SampleCallback(IMediaSample pSample)
        {
            int hr;
            IntPtr pData;
            try
            {
                // Get the buffer into which we will copy the data
                hr = pSample.GetPointer(out pData);
                if (hr >= 0)
                {
                    // Set TRUE on every sample for uncompressed frames
                    hr = pSample.SetSyncPoint(true);
                    if (hr >= 0)
                    {
                        // Find out the amount of space in the buffer
                        int cbData = pSample.GetSize();
                        hr = SetTimeStamps(pSample, m_iFrameNumber);
                        if (hr >= 0)
                        {
                            int iRead;
                            // Get copy the data into the sample
                            hr = GetImage(m_iFrameNumber, pData, cbData, out iRead);
                            if (hr == 0) // 1 == End of stream
                            {
                                pSample.SetActualDataLength(iRead);
                                // increment the frame number for next time
                                m_iFrameNumber++;
                            }
                        }
                    }
                }
            }
            finally
            {
                // Release our pointer the the media sample.  THIS IS ESSENTIAL!  If
                // you don't do this, the graph will stop after about 2 samples.
                Marshal.ReleaseComObject(pSample);
            }
            return hr;
        }
    }
