    public class BaseEntity
    {
       private string _createdBy;
       private DateTime _createdDate;
       private string _updatedBy;
       private DateTime _updatedDate;
    }
    
    public class User : BaseEntity
    {
       private string _username;
       private string _password;
       private Employee _employee;
        
       //set get 
    }
