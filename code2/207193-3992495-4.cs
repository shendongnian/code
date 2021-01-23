    class A
    { 
         int Prop1 { get; set; }
         int Prop2 { get; set; }
    }
    public A SomeMethod()
    {
        return new A() { Prop1 = 1, Prop2 = 2 }
    }    
