    foreach(var obj in objects)
    {
        if(obj is DerivedTypeA) //type checking needed
        {
            obj.TypeASpecificMethod();
        }
        else if (obj is DerivedTypeB)
        {
            obj.TypeBSpecificMethod();
        }
        else if (obj is DerivedTypeC)
        {
            obj.TypeCSpecificMethod();
        }
    }
