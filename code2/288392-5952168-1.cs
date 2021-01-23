    constant String defaultString = String.Empty; //change this later if the default value needs to be something else, can't remember if the syntax is valid C# ;)
    //...
    public void Foo(string message = defaultString)
    {
       Console.WriteLine(message);
    }
