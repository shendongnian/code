    class CompressorThreads : CompressorClassEvents, ICodeProgress
    {
        void ICodeProgress.SetProgress(long inSize, long outSize)
        {
            System.Diagnostics.Debug.WriteLine("processedInSize:" + inSize + "  processedOutSize:" + outSize);
        }
        private void Compress(string filePath, string compressedFilePath)
        {
            . . .
            encoder.Code(inStream, outStream, -1, -1, this);
            . . .
        }
    }
