    private string GetFileSize(double byteCount)
    {
            string size = "0 Bytes";
            if (byteCount > = 1073741824.0)
            {
               size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            }
            else if (byteCount >= 1048576.0)
            {
                //do something else in here
            }
            return size;
    }
