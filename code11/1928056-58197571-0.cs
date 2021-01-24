    string Foo(Resource parameter = null)
    {
        if (parameter == null)
        {
            using (var res = new Resource())
            {
                return DoSomething(res);
            }
        }
        else 
        {
            return DoSomething(res);
        }
        string DoSomething(Resource res)
        {
            res.Something();
            /...../
            return /...../
        }
    }
