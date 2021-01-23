    [DataContract]
     public class Person 
      {
        public Person ()
        {
        }
        [DataMember(Name = "Name")]
        public string mName { get; set; }
        [DataMember(Name = "Age")]
        public int mAge { get; set; }
        [DataMember(Name = "Single")]
        public bool mIsSingle { get; set; }
      
    
    
        [System.Runtime.Serialization.OnDeserialized]
        void OnDeserialized(System.Runtime.Serialization.StreamingContext c)
        {
          mAge = 18;
        }
      }
    }
