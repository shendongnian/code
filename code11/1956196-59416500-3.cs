    public void Create(SetType set)
    {
        var constants = ConstantSets[set];
        var foo = new Foo(constants.Name) {
            Health = constants.Health
        };
        if (constants.MaxTries is int maxTries) {
            foo.Add(maxTries);
        }
    }
