    // ...
    public IEnumerable<ConstraintViolation> GetViolations(SomeType value)
    {
        if(value == 42)
        {
            yield return new ConstraintViolation(this, "Value cannot be 42");
        }
        foreach(var subViolation in subConstraint.GetViolations(value))
        {
            yield return subViolation;
        }
    }
    private SomeSubConstraint subConstraint;
