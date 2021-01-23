    private Point GetMaxFrameSize(IPin pStill)
        {
            VideoInfoHeader v;
            IAMStreamConfig videoStreamConfig = pStill as IAMStreamConfig;
            int iCount = 0, iSize = 0;
            videoStreamConfig.GetNumberOfCapabilities(out iCount, out iSize);
            IntPtr TaskMemPointer = Marshal.AllocCoTaskMem(iSize);
            int iMaxHeight = 0;
            int iMaxWidth = 0;
            AMMediaType pmtConfig = null;
            for (int iFormat = 0; iFormat < iCount; iFormat++)
            {
                IntPtr ptr = IntPtr.Zero;
                videoStreamConfig.GetStreamCaps(iFormat, out pmtConfig, TaskMemPointer);
                v = (VideoInfoHeader)Marshal.PtrToStructure(pmtConfig.formatPtr, typeof(VideoInfoHeader));
                if (v.BmiHeader.Width > iMaxWidth)
                {
                    iMaxWidth = v.BmiHeader.Width;
                    iMaxHeight = v.BmiHeader.Height;
                }
            }
            Marshal.FreeCoTaskMem(TaskMemPointer);
            DsUtils.FreeAMMediaType(pmtConfig);
            return new Point(iMaxWidth, iMaxHeight);
        }
        /// <summary>
        ///  Free the nested structures and release any
        ///  COM objects within an AMMediaType struct.
        /// </summary>
        public static void FreeAMMediaType(AMMediaType mediaType)
        {
            if (mediaType != null)
            {
                if (mediaType.formatSize != 0)
                {
                    Marshal.FreeCoTaskMem(mediaType.formatPtr);
                    mediaType.formatSize = 0;
                    mediaType.formatPtr = IntPtr.Zero;
                }
                if (mediaType.unkPtr != IntPtr.Zero)
                {
                    Marshal.Release(mediaType.unkPtr);
                    mediaType.unkPtr = IntPtr.Zero;
                }
            }
        }
