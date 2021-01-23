    namespace Foo.Enums
    {
        [DataContract]
        public enum EAccountStatus
        { 
            [DataMember]
            Online,
            [DataMember]
            Offline,
            [DataMember]
            Pending
        }
