    public Term Times(Term other)
    {
        // This would work because you would've defined an implicit conversion
        // from double to Term.
        return _value * other._value;
    }
    public Term DividedBy(Term other)
    {
        // Same as above.
        return _value / other._value;
    }
