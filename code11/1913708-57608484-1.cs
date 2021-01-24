    public enum ValueType
    {
        MaxHP,
        Strength,
        Defense,
        CurrentHP
    }
    private Dictionary<ValueType, int> Values = new Dictionary<Value, int>
    {
        {ValueType.MaxHP, 100},
        {ValueType.Strength, 0 },
        {ValueType.Defense, 0 },
        {ValueType.CurrentHP, 0 }
    };
    public void ChangeValue(ValueType valueType, int value)
    {
        Values[valueType] += value;
        // do additional stuff
    }
    
