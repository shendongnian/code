    public class MyClass
    {
      private string _type;
      [JsonIgnore]
      public Type type {get => Assembly.GetType(_type, true, false); set => value.Fullname;}
    }
