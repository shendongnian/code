    public class Foo
    {
        public bool DoNotShow { get; set; };
    
        public void DoSomething() {
            if(this.DoNotShow == true) {
                // logic
            } else {
                // alternative logic
            }
        }
    }
    public class Boo
    {
        privite Foo foo;
    
        public void SomeMethod()
        {
            ...
            foo.DoSomething();
            foo.DoNotShow = true;
            ...
            foo.DoSomething();
        }
    }
