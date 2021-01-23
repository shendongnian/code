    interface INamedProperty
    {
        // Informational
        Type ContainingType { get; }
        string Name { get; }
        Type ReturnType { get; }
        // Operations (for example)
        void CopyTo(object obj, INamedProperty property);
    }
