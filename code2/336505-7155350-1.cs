    class Test : IDisposable {
        private CppWrapper obj;
        //...
        public void Dispose() {
           if (obj != null) { 
               obj.Dispose();
               obj = null;
           }
        }
    }
