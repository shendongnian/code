    _messageProcessing.Add("input", (x, y, z) => "output");
    _messageProcessing.Add("another", (x, y, z) => "example");
    // ...
    delegate string DispatchFunc(DynamicEntity first, DynamicEntity second,
                                 IEnumerable<DynamicEntity> collection);
    Dictionary<string, DispatchFunc> _messageProcessing;
