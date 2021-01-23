    public class MyClass:IHost
    {
       public Dictionary<int,string>; dic { get; set;}
    
       public MyClass()
       {
           dic =  new Dictionary<int,string>();
       }
    
       public void Add(int key, string value)
       {
           dic.Add(key, value);
       }
    }
    
    public class  MyClass2 : IHost
    {
        MyClass1 _class1;
    
        public MyClass2(MyClass1 instance)
        {
            _class1 = instance;
        }
    
        public void Save()
        {
          _class1.Add(1,"vxcvcx");
        }
    }
