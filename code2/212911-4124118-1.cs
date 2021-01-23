    SomeClass instance = new SomeClass();
    instance.InstanceMethod();   //Fine
    instance.StaticMethod();     //Will give Warning BC42025*
    SomeClass.InstanceMethod();  //Won't compile
    SomeClass.StaticMethod();    //Fine
