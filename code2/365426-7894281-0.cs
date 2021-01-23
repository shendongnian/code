    void Foo()
    {
        ProductType productType = GetProductType(userId);
        SomeThingType someThingType = GetSomeThingTypeFromDb(userId);
        switch(productType)
        {
            case ProductType.ONE:
                IThing a = CreateThing(someThingType, ...);
                break;
            ...
        }
        ...
    }
    
    IThing CreateThing(SomeThingType someThingType , ...)
    {
        switch(someThingType )
        {
            case SomeThingType.X:
                return new SomeThing<int>(...);
    
            case SomeThingType.Y:
                return new SomeThing<string>(...);
            case SomeThingType.Z:
                return new SomeThing<DateTime>(...);
            default:
                throw new ArgumentException(...);
        }
    }
