    object v = myCell.Value;
    if(v is int)
    {
        int vInt = (int)v;
        // ...
    }
    else if(v is string)
    {
        string vStr = (string)v;
        // ...
    }
    else if(v is MyClass)
    {
        MyClass vMyClass = (MyClass)v;
        // ...
    }
    // ...
