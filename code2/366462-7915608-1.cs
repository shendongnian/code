    public class ApiResult<T>
    {
        [DataMember]
        public ApiCode Code
        {
            get;
            set;
        }
        [DataMember]
        public String Error
        {
            get;
            set;
        }
        [DataMember]
        public T Context
        {
            get;
            set;
        }
    }
