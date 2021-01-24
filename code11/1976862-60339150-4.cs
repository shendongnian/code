    Outer toSerialise = new Outer 
    {
        SomeStringProperty = "MyOuterValue",
        SomeClassProperty = new Inner
        {
            InnerProperty1 = "MyInnerValue1",
            InnerProperty2 = "MyInnerValue2"
        }
    };
    
    var queryObject = new { toSerialise.SomeStringProperty, toSerialise .Inner.InnerProperty1, toSerialise.Inner.InnerProperty2 }
