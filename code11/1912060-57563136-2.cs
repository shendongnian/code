    class Program
    {
        static void Main(string[] args)
        {
            foreach (string location in new CertEnumSystemStoreLocations())
                Console.WriteLine(location);
        }
    }
    public class CertEnumSystemStoreLocations : IEnumerable, IEnumerator<string>
    {
        private EventWaitHandle _eventBeginMoveNext;
        private EventWaitHandle _eventEndMoveNext;
        private string _current;
        private Thread _thread;
        public CertEnumSystemStoreLocations()
        {
            _eventBeginMoveNext = new EventWaitHandle(false, EventResetMode.AutoReset);
            _eventEndMoveNext = new EventWaitHandle(false, EventResetMode.AutoReset);
            _thread = new Thread(new ThreadStart(CertEnumSystemStoreLocationThread));
            _thread.Start();
        }
        private void CertEnumSystemStoreLocationThread()
        {
            NativeMethods.CertEnumSystemStoreLocation(0, new IntPtr(), Callback);
            _eventBeginMoveNext.WaitOne();
            _current = null;
            _eventEndMoveNext.Set();
        }
        private bool Callback(IntPtr storeLocation, uint flags, IntPtr reserved, IntPtr stateObject)
        {
            _eventBeginMoveNext.WaitOne();
            _current = Marshal.PtrToStringUni(storeLocation);
            _eventEndMoveNext.Set();
            return true;
        }
        public string Current
        {
            get
            {
                return _current;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            _eventBeginMoveNext.Set();
            _eventEndMoveNext.WaitOne();
            return _current != null;
        }
        public void Reset()
        {
            // TODO ... you'd need to tell the callback in the thread to
            // stop waiting on events etc. and then wait for the whole 
            // thread to run out ... 
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
    public static class NativeMethods
    {
        [DllImport("crypt32", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool CertEnumSystemStoreLocation(uint reserved,
                                                              IntPtr stateObject,
                                                              CertEnumSystemStoreLocationCallback callback);
        public delegate bool CertEnumSystemStoreLocationCallback(IntPtr storeLocation,
                                                                 uint flags,
                                                                 IntPtr reserved,
                                                                 IntPtr stateObject);
    }
