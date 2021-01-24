    class A{
     public List<B> List {get; set;}
    }
    class B{
     public string Property {get; set;}
    }
    
                List<B> bb = new List<B>()
                {
                    new B { Property = "AAA" },
                    new B { Property = "BBB" }
                };
    
                List<A> aa = new List<A>() {
                    new A {List = bb }
                };
