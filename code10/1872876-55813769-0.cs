    ...
    public string GiveMeAString()
    {
        return "Something about " + global::Thing.VariableProperty;
        // Or
        // return "Something about " + My.Namespace.Thing.VariableProperty;
    }
    ...
