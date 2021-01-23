    public class User {
        public string Email { get; set; }
        public string FirstName { get; set; }
    
        [MyAttrubute]
        public string LastName { get; set; }
    }
    
    [MyAttrubute]
    public class OtherClass {
    
        [MyAttrubute]
        public string AnotherProperty { get; set; }
    }
