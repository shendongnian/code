    class DateCompareFileInfo : IComparer<FileInfo>
    {
        /// <summary>
        /// Compare the last dates of the File infos
        /// </summary>
        /// <param name="fi1">First FileInfo to check</param>
        /// <param name="fi2">Second FileInfo to check</param>
        /// <returns></returns>
        public int Compare(FileInfo fi1, FileInfo fi2)
        {
            int result;
            if (fi1.LastWriteTime == fi2.LastWriteTime)
            {
                result = 0;
            }
            else if (fi1.LastWriteTime < fi2.LastWriteTime)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }
    }
