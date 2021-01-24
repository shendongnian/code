    namespace MyResult
    {
        [DataContract]
        public class ResultType1 : ResultBase
        {
            [DataMember]
            [RosterCategory("Location")]
            public RosterItem location { get; protected set; }
            [DataMember]
            [RosterCategory("Status")]
            public RosterItem status { get; protected set; }
        }
        [DataContract]
        public class ResultType2 : ResultBase
        {
            [DataMember]
            [RosterCategory("Location")]
            public RosterItem location { get; protected set; }
            [DataMember]
            [RosterCategory("Equipment")]
            public RosterItem equipment { get; protected set; }
            [DataMember]
            public string Name { get; protected set; }
        }
    }
