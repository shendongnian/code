    public class Entity
    {
         public Right[] Rights { get; set; }         
    }
    public class Right
    {
         public User user {get;set;}
         public Permission[] permissions {get;set;}
    }
    public class Foo : Entity
    {
         
    }
    public class Bar : Entity
    {
    }
