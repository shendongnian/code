      public class TestCulture : IDisposable {
        private CultureInfo m_SavedCulture; 
        private bool m_IsDisposed;
        public TestCulture() {
          m_SavedCulture = CultureInfo.CurrentCulture; 
          CultureInfo testCulture = CultureInfo.CurrentCulture.Clone() as CultureInfo;
          testCulture.NumberFormat = CultureInfo.InvariantCulture.NumberFormat;
          testCulture.DateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
          CultureInfo.CurrentCulture = testCulture;
        }
        protected vitrual void Dispose(bool disposing) {
          if (disposing) {
            if (!m_IsDisposed && ReferenceEquals(CultureInfo.CurrentCulture, testCulture)) {
              CultureInfo.CurrentCulture = m_SavedCulture;
              m_IsDisposed = true;
            }
          }
        }
        public void Dispose() => Dispose(true);
      }
