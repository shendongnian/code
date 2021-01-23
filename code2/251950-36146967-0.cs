    var dict = new Dictionary<string, IList>();
    dict.Add("u", new List<U>());
    dict.Add("v", new List<V>());
    
    // in case of members you know they exist on an IList
    dict["u"].Add(new U());
    dict["v"].Add(new V());
    // in case you know what you are going to get back, in which case you should cast
    var uProperty = (dict["u"][0] as U).UProperty
    var vProperty = (dict["v"][0] as V).VProperty
    // in case your're not sure of     
    (dict[someKey] as dynamic)[someIndex].SomeMember...;
