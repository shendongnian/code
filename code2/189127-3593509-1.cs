    class ComObjectCleanUp : IDisposable {
        private T obj;
        public ComObjectCleanUp(T obj) {
            this.obj = obj;
        }
        public void Dispose() {
            if (obj != null)
                Marshal.FinalReleaseComObject(obj);
        }
    }
