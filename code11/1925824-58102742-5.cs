    //Needed by InformationGetter to perform its function
    public class InformationGetterOptions {
        public string ConnectionString { get; set; }
        public string StoredProcedureName { get; set; }
    }
    //abstraction of InformationGetter
    public interface IInformationGetter {
        string GetUserInformation(int userId);
    }
    //implementation.
    public class InformationGetter : IInformationGetter{  
        private readonly InformationGetterOptions options;
        public InformationGetter(InformationGetterOptions options) {
            this.options = options;
        }
        public string GetUserInformation(int userId) {
            //use values in options to connect
            // Do SQL work
            return info;
        }
    }
