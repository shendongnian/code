    // not a class, context is IEnumerable, not a single entitry
    // Returns true if OK, false if any element is not the same.
    // 'Sameness' (equality) defined in Info-class as implemented by IEquatable
    public bool Validate(IEnumerable<Info> context)
    {
        for (int i = 0; i < context.Count(); i++)
        {
            for (int j = i + 1; j < context.Count(); j++)
            {
                if (!context[i].Equals(context[j])) {return false;}
            }
        }
        return true;
    }
