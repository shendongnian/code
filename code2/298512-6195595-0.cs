    class MyType
    {
       public MyEnum MyEnum {get; private set;}
       private string DBEnum { set { MyEnum = Convert(value);}
    
       private MyEnum Convert(string val)
       {
         // TODO: Write me 
       } 
    }
    
    // cnn.Query<MyType>("select 'hello' as DBEnum")  <-- will set MyEnum
