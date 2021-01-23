    void Main()
    {
        MethodInfo sayHelloMethod = typeof(Person).GetMethod("SayHello");
        OpenAction<Person, string> action =
            (OpenAction<Person, string>)
                Delegate.CreateDelegate(
                    typeof(OpenAction<Person, string>),
                    null,
                    sayHelloMethod);
    
        Person joe = new Person { Name = "Joe" };
        action(joe, "Jack"); // Prints "Hello Jack, my name is Joe"
    }
    
    delegate void OpenAction<TThis, T>(TThis @this, T arg);
    
    class Person
    {
        public string Name { get; set; }
        
        public void SayHello(string name)
        {
            Console.WriteLine ("Hi {0}, my name is {1}", name, this.Name);
        }
    }
