    class MyClass : IDisposable {
    
        static void IfNotNullDispose(ref IDisposable disposable) {
            if (disposable != null) {
                disposable.Dispose();
                disposable = null;
            }
        }
    
        public void Dispose() {
             IfNotNullDispose(ref m_field1);
             IfNotNullDispose(ref m_field2);
             // etc
        }
    }
