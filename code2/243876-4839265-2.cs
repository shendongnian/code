    [CollectionDataContract]
    public class People : List<Person>
    {
          
    }
        
    [DataContract]
    public class Person
    {
         public Person() { }
                            
         [DataMember]
         public int Id{ get; set; }
                
         [DataMember]
         public string Name { get; set; }
    }
