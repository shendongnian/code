    public abstract class Repository : IDisposable  
    { 
        public void Dispose() { Dispose(true); }
        protected virtual Dispose(bool disposing) {  } 
    }
    public class NHibernateRepository : Repository { /* Impl here, add disposal. */ }
    public class TestRepository : Repository { /* Impl with no resources */ }
