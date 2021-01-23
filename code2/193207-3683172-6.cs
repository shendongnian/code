    public Term Times(Term multiplier)
    {
        // This would work because you would've defined an implicit conversion
        // from double to Term.
        return _value * multiplier._value;
    }
    public Term DividedBy(Term divisor)
    {
        // Same as above.
        return _value / divisor._value;
    }
