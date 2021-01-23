    public class ShareArray
    {
        private System.Collections.ArrayList arrayList;
    
        #region Property
        public System.Collections.ArrayList ArrayList { get; set; }
        #endregion
    
        #region Imp. signletone
        public static ShareArray instance;
        public static ShareArray Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShareArray();
                }
                return instance;
            }
        }
    
    
        private ShareArray()
        {
            arrayList = new System.Collections.ArrayList();
        }
        #endregion
    }
