        [DataContract]
        public class DataClass
        {
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public int BirthYear { get; set; }
            public override string ToString()
            {
                return "FirstName : '" + FirstName + "', BirthYear: " + BirthYear;
            }
        }
        [DataContract]
        public class ResultSingle 
        {
            [DataMember]
            public DataClass Data { get; set; }
        }
        [DataContract]
        public class ResultArray 
        {
            [DataMember]
            public List<DataClass> Data { get; set; }
        }
