    public class CDFReader : IDisposable
    {
        private Mutext _myMutex = new Mutex(false, "CDFDLLMutex");
    
        public CDFReader(string path)
        {
            _myMutex.WaitOne();   //This locks the DLL for the life of the CDFReader
            // open cdf file using dll
        }
    
        // other cdf extraction methods exist that require the dll
    
        //In your dispose method (because this class is IDisposable) call _myMutex.ReleaseMutex() and _myMutex.Dispose()
    }
    
    
    public class SomeOtherClass
    {
        // function call to CDFReader that gets called from
        // multiple request threads
        public Records GetRecords()
        {
            //No modification needed to this method
            using (var cdf = CDFReader(somefilepath))
            {
                // extract data from cdf using CDFReader methods
            }
        }
    }
