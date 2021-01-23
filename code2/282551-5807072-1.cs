    var a = IsBoxed(3); // false
    var b = IsBoxed("abc"); // false
    var c = IsBoxed<ValueType>(9); // true
    var d = IsBoxed<int?>(new int?()); //true
    var e = IsBoxed<object>(null); // false
    
    // Says false, but this is impossible to work out, really.
    var f = IsBoxed<object>(new int?());
