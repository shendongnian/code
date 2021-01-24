c#
    static public class UnZip
    {
        [DllExport("UngzipFile", CallingConvention.StdCall)]
        public static int UngzipFile([MarshalAs(UnmanagedType.LPWStr)] string aFile)
        {
            if (!File.Exists(aFile))
                return 3;
            FileInfo fileInfo;
            string logFile = @"D:\Temp\logDll.log";            
            try
            {
                File.AppendAllText(logFile, aFile);
                fileInfo = new FileInfo(aFile);
            }
            catch(Exception ex)
            {
                File.AppendAllText(logFile, String.Format("File : {0} || Exception : {1}",aFile,ex.Message));
                return 2;
            }
            int result = 0;
            using (FileStream fileToDecompress = fileInfo.OpenRead())
            {
                string decompressedFileName = Path.Combine(Path.GetDirectoryName(aFile), "temp.sql");
                using (FileStream decompressedStream = File.Create(decompressedFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(fileToDecompress, CompressionMode.Decompress))
                    {
                        try
                        {
                            decompressionStream.CopyTo(decompressedStream);
                        }
                        catch
                        {
                            result = 1;                            
                        }
                    }
                }
            }
            return result;
        }
    }
By adding "[MarshalAs(UnmanagedType.LPWStr)]" in my parameter declaration, this resolve the problem.
Thaks Rudy for your help.
