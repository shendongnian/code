    // adding delegates
    if (dictionary.ContainsKey(KeyEnum.W)) {
        dictionary[KeyEnum.W] += SomeMethod;
    } else {
        dictionary.Add(KeyEnum.W, SomeMethod);
    }
    // calling delegates
    if (dictionary.ContainsKey(KeyEnum.W)) {
        dictionary[KeyEnum.W](...);
    }
