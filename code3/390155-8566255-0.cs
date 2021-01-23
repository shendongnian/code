    [DataContract]
     public class Person 
      {
        public Person ()
        {
        }
        [DataMember(Name = "Name")]
        public string mName { get; set; }
        [DataMember(Name = "Age")]
        public int mAge = 18;
        [DataMember(Name = "Single")]
        public bool mIsSingle { get; set; }
      };
