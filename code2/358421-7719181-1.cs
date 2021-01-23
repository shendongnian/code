     [DataContract]
     public class Person
    {
       [DataMember]
       public int Identifier { get; set; }
       [DataMember]
       public string First { get; set; }
       [DataMember]
       public string Last { get; set; }
       public string FullName()
       {
          return First + " " + Last;
       }  
    }
  
