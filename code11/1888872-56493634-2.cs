    class ComReleaseWrapper : IDisposable
    {
        object _obj;
        public ComReleaseWrapper(object o) {
           _obj = o;
        }
        public object Object { get { return _obj; } }
        public void Dispose() {
            if (_obj) {
                Marshal.ReleaseComObject(_obj);
                if (_obj is IDisposable d) d.Dispose();
            }
            _obj = null;
        }
     }
     using (var kernelWrap = new ComReleaseWrapper(new Kernel()) {
        var kernel = kernelWrap.Object as Kernel;
     }
