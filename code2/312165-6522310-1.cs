    public class DataModel {
        public DataModel()
        {
            using (btWholesaleDataContext db = new btWholesaleDataContext()) {
                //! requires auth
                var MACRequestList = ... ;
                MACRequests = MACRequestList.ToList(); // ToList reads the records now, instead of later.
            }
        }
        public List<Models.BT.Request> MACRequests { get; private set; }
    }
