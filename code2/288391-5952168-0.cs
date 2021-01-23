    constant String k_dflt_str = String.Empty; //change this later if the default value needs to be something else, can't remember if the syntax is valid C# ;)
    //...
    public void Foo(string message = k_dflt_str)
    {
       Console.WriteLine(message);
    }
