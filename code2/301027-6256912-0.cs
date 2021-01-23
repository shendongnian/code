    public override bool Equals(object obj)
    {
        return Equals(obj as Node);
    }
    public bool Equals(Node node)
    {
        if (Node == null)
            return false;
        // ... do the type-specific comparison.
    }
