        public class BasicSession : IMySession
        {
            #region IMySession members
     
            public void StoreName(string name)
            {
                // plain store
            }
            public void StoreAddress(string address)
            {
                // plain store
            }
            public void Commit()
            {
                // plain commit
            }
            #endregion
        }
