    public class ActivityTypeAttribute : Attribute 
    {
     public Name { get; set; }
    }
    
    [ActivityType(Name="MyClass")]
    public class MyClass { }
    
    ...
    {
     ActivityTypeAttribute att = (ActivityTypeAttribute)Attribute.GetCustomAttribute(typeof(MyClass), typeof(ActivityTypeAttribute));
    
      Debug.Assert( att.Name == "MyClass" );
    }
    ...
