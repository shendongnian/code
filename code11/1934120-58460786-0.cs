deser = new DataContractJsonSerializer(typeof(List<T>));
Should likely be something like
deser = new DataContractJsonSerializer(typeof(CourseWork));
#2 
  [DataMember(Name = "assignmentname")]
        public List<Assignment> Assignment
quite likely should be 
  [DataMember(Name = "assignments")]
        public List<Assignment> Assignment
        {
