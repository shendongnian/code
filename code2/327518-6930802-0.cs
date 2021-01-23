    public void MyMethod<Ttype>(Ttype myClass)
    {
        string className = typeof(Ttype).Name;
        switch (className)
        {
            case "NetClassA":
                // Do stuff
                break;
            case "NetClassB":
                // Do stuff
                break;
            default:
                // Do something if necessary
                break;
         }
    }
