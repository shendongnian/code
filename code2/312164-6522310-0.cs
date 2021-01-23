    public class DataModel : IDisposable {
        private btWholesaleDataContext wholesaleDataContext;
        public DataModel()
        {
            wholesaleDataContext = new btWholesaleDataContext();
            //! requires auth
            var MACRequestList = ... ;
            MACRequests = MACRequestList.AsQueryable();
        }
        public IQueryable<Models.BT.Request> MACRequests { get; private set; }
        public void Dispose() {
            if(wholesaleDataContext != null)
                wholesaleDataContext.Dispose();
        }
    }
