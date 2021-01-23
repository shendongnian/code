    public class UserSettings
    {
     string FirstName { get; set; }
     string LastName { get; set; }
     // etc.
    }
    
    public class MyClass
    {
     string MyClassProperty1 { get; set; }
     // etc.
     
     UserSettings MySettings { get; set; }
    }
