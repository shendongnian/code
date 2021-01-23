    [DataContract]
    public class User
    {
    }
    [DataContract]
    public class Service1User : User
    {
      [DataMember] public string PropertyVisibleOnlyForService1{...}
    }
    [DataContract]
    public class Service2User : User
    {
      [DataMember] public string PropertyVisibleOnlyForService2{...}
    }
    
    [ServiceContract]
    public interface IService1  
    {   
       List<Service1User> GetUsers();  // user with 'PropertyVisibleOnlyForService1' inside
    }
    
    [ServiceContract]
    public interface IService2  
    {   
        List<Service2User> GetUsers(); // user with 'PropertyVisibleOnlyForService2' inside 
    }
