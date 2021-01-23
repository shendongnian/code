    public async Task<int> SomethingAsync()
    {
        // Create and initialize a MyClass object
        MyClass myObject = await MyClass.CreateAsync(...);
        // use the created object:
        return await myObject.OtherFunctionAsync(4, 7);
    }
