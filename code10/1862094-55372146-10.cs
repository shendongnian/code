      public class TestCulture : IDisposable {
        private CultureInfo m_SavedCulture; 
        private CultureInfo m_TestCulture;
        private bool m_IsDisposed;
        public TestCulture() {
          m_SavedCulture = CultureInfo.CurrentCulture; 
          m_TestCulture = CultureInfo.CurrentCulture.Clone() as CultureInfo;
          m_TestCulture.NumberFormat = CultureInfo.InvariantCulture.NumberFormat;
          m_TestCulture.DateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
          CultureInfo.CurrentCulture = m_TestCulture;
        }
        protected vitrual void Dispose(bool disposing) {
          if (disposing) {
            if (!m_IsDisposed && ReferenceEquals(CultureInfo.CurrentCulture, m_TestCulture)) {
              CultureInfo.CurrentCulture = m_SavedCulture;
              m_IsDisposed = true;
            }
          }
        }
        public void Dispose() => Dispose(true);
      }
