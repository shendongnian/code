    class MyEncoder : ICodeProgress
    {
        void SetProgress(Int64 inSize, Int64 outSize)
        {
            System.Diagnostics.Debug.WriteLine("processedInSize:" + inSize + "  processedOutSize:" + outSize);
        }
        private void Compress(string filePath, string compressedFilePath)
        {
            . . .
        }
    }
