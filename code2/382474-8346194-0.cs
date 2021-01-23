    Dictionary<string, MyClass> MyStronglyTypedDictionary = 
       new Dictionary<string, MyClass>();
    //populate MyStronglyTypedDictionary
    //a Dictionary<T1, T2> is an IEnumerable<KeyValuePair<T1, T2>>
    //so most basic Linq methods will work
    Dictionary<string, object> MyGeneralDictionary = 
       MyStronglyTypedDictionary.ToDictionary(kvp=>kvp.Key, kvp=>(object)(kvp.Value));
