    namespace DAL {
        public partial class DataDataContext
        {
            public DataDataContext() :
                this(/* Get your connection string here */)
            {
                OnCreated();
            }
        }
     }
