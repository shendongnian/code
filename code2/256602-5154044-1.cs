    public class SomeEnum : AbstractEnum<SomeEnum> 
    {
        
            public static readonly SomeEnum V1;
            public static readonly SomeEnum V2;
        
            public static void Initialize()
            {
              V1 = new SomeEnum("V1");
              V2 = new SomeEnum("V2"); 
            }
        
            SomeEnum(String name) : base(name) {
            }
        }
