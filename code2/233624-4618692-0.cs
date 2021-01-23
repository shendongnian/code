    namespace bar
    {
        interface IBar
        {
            public int BarProp { get; set; }
        }
    }
    
    //IFoo.cs
    namespace foo
    {
        using bar;
        interface IFoo
        {
            public IBar FooProp { get; set; }
        }
    }
    
    //elsewhere.cs
    namespace foo
    {
    
        class test: IFoo {
    
            public test (){
        //using bar //without this, 
        IFoo myFoo = new test();
        int val = myFoo.FooProp.BarProp; //<-- **BarProp is not inaccessable here**
            }
        }
    }
