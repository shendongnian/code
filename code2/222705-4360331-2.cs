    public string myProperty = "foobar";
    public Task t;
     //case #1: move code to constructor, this works
     public Foo()
     {
        t = Task.Factory.StartNew(() =>
        {
            myProperty = "test";
        });
     }
 
     //case #2:
     public Task tFoo = Task.Factory.StartNew(() =>
     {
        //THIS won't compile: A field initializer cannot ref..
        myProperty = "test";
     });
     //case #3:Use a method instead
     public Task GetTask() //THIS will work
     {
        Task t = Task.Factory.StartNew(() =>
        {
            myProperty = "test";
        });
        return t;
     }
    }
