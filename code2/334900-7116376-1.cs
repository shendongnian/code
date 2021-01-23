    // most readable
    public int GetValue(int? value)
    {
        return value.GetValueOrDefault();
    }
---
    // less readable
    public int GetValue(int? value)
    {
        return value ?? default(int);
    }
