    namespace DAL {
        public partial class DataDataContext
        {
            public DataDataContext() :
                base(global::DAL.Properties.Settings.Default.MyConnectionString, mappingSource)
            {
                OnCreated();
            }
        }
     }
