    // Use standard Child
    public Child Add(string initInfo)
    {
        Child newChild = new Child(this.Parent);
        // There's actually a bit more coding before Initialize()
        // in the real thing, but nothing relevant to the example.
        newChild.Initialize(initInfo);
        List.Add(newChild);
        return newChild;
    }
    // Overload for derived Child.
    public Child Add(Type childDerivative, string initInfo)
    {
        if (!childDerivative.IsSubclassOf(typeof(Child)))
            throw new ArgumentException("Not a subclass of Child.");
        ConstructorInfo ci = childDerivative.GetConstructor(
            BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.FlattenHierarchy |
            BindingFlags.ExactBinding, 
            null, new Type[] { typeof(Parent) }, null);
        if (ci == null)
            throw new InvalidOperationException("Failed to find proper constructor.");
        newChild = (Child)ci.Invoke(new Object[] { this.Parent });
        newChild.Initialize(initInfo);
        List.Add(newChild);
        return newChild;
    }
