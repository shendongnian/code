    // Operator overloads
    public static Measurement<TUnit> operator +(Measurement<TUnit> left,
                                                Measurement<TUnit> right)
    {
        return new Measurement<TUnit>(left.Value + right.GetValueAs(left.Unit), left.Unit);
    }
