    public class DataModel : IDisposable {
        btWholesaleDataContext db = new btWholesaleDataContext();
        public void Dispose() 
        {
            btWholesaleDataContext.Dipose();
        }
        public IQueryable<Models.BT.Request> MACRequests { 
              get {
                                     return from r in db.btRequests
                                     select new Models.BT.Request {
                                         ID = r.ID,
                                         Date = r.DateTime,
                                         StatusCode = 3,
                                         Status = r.Status
                                     };
              } 
        }
    }
