    Dictionary<string, MyClass> MyStronglyTypedDictionary = 
       new Dictionary<string, MyClass>();
    //populate MyStronglyTypedDictionary
    //a Dictionary<T1, T2> is an IEnumerable<KeyValuePair<T1, T2>>
    //so most basic Linq methods will work
    Dictionary<string, object> MyGeneralDictionary = 
       MyStronglyTypedDictionary.ToDictionary(kvp=>kvp.Key, kvp=>(object)(kvp.Value));
    ...
    
    //Now, changing a MyClass instance's data values in one Dictionary will 
    //update the other Dictionary
    ((MyClass)MyGeneralDictionary["Key1"]).MyProperty = "Something else";
    if(MyStronglyTypedDictionary["Key1"].MyProperty == "Something else")
    {
        //the above is true; this code will execute
    }
    //But changing a MyClass reference to a completely new instance will
    //NOT change the original Dictionary
    MyGeneralDictionary["Key1"] = new MyClass{MyProperty = "Something new"};
    if(MyStronglyTypedDictionary["Key1"].MyProperty == "Something else")
    {
        //the above is STILL true even though the instance under this key in the other
        //Dictionary has a different value for the property
    }
