    public void MySpecialMethod(this IEnumerable<ISomething> objects) // <- the problem
    {
        foreach (ISomething o in objects)
            o.A();   
    }
