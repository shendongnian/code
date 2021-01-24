    string Foo(Resource parameter = null)
    {
        if (parameter != null)
        {
            return DoSomething(parameter);
        }
        using (var resource = new Resource())
        {
            return DoSomething(resource);
        }
        string DoSomething(Resource res)
        {
            res.Something();
            /...../
            return /...../
        }
    }
