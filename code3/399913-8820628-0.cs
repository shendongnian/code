    public decimal Multiply(IEnumerable<CurveValue> curve, decimal dVal)
    {
        IEnumerable<CurveValue> curveA = curve.Select(c => new Curve { Value = decimal.Round(c.Value, 4) * dVal });
        return Sum(curveA);
    }
    public decimal Sum(IEnumerable<CurveValue> curveA)
    {
        return curveA.Sum(x => x.Value);
    }
