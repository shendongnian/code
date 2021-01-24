    public static var lock = new ReaderWriterLock();
        public static void WriteToFile(string text)
        {
            try
            {
                string fileName = "";
                lock.AcquireWriterLock(int.MaxValue); 
    
                File.AppendAllLines(fileName);
            }
            finally
            {
                lock.ReleaseWriterLock();
   
            }
        }
