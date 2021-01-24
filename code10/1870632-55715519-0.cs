    private const string OptionalValue = "This is optional!";
    public void myFunction(bool required, string optional = OptionalValue)
    {
        optional = optional ?? OptionalValue;
    }
