    // Predicate which returns true if o.property is true AND o.anotherProperty is not null...
    static bool ObjectIsValid(Foo o)
    {
        if (o.property)
        {
            return o.anotherProperty != null;
        }
        return false;
    }
    myBool = myList.Any(ObjectIsValid);
