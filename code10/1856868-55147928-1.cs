    public static void Foo()
    {   
       //Singleton start
       private static ReadOnly Foo instance;
       private Foo() {}
    
       public static Foo Instance
       {
            get{
              if(instance == null){
                 instance = new Foo();
                 }
                 return instance;
                 }
       }
       //Singleton end
       public static void method1()
       {
            // context is null
            var context = Container.Resolve<IUserContext>();
       }
    }
