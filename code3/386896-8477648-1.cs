    [DataContract]
        public class ServiceResult<T>
        {
            [DataMember]
            public T GetComplexDataResult{ get; set; }
        }
