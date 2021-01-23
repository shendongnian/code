    private class1 myFunction (MyType t , int id , string name)
    {
        class1 obj;
        switch(t)
        {
            case MyTypes.Type1:
               obj = new Class1();
            ...
        }
    
        obj.type = t ;
        obj.id = id ;
        obj.name = name;
        return obj;
    }
