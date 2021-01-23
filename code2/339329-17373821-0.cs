    class MyClass : IDisposable {
         public void Dispose() {
             if (!m_field1 != null) {
                 m_field1.Dispose();
                 m_field1 = null;
             }
             if (!m_field2 != null) {
                 m_field2.Dispose();
                 m_field2 = null;
             }
             // etc
         }
    }
