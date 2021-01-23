    SomeClass instance = new SomeClass();
    instance.InstanceMethod();   //Fine
    instance.StaticMethod();     //Won't compile
    SomeClass.InstanceMethod();  //Won't compile
    SomeClass.StaticMethod();    //Fine
