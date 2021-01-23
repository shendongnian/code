    // most readable
    public int GetValue(int? value)
    {
        return value ?? default(int);
    }
---
    // less readable
    public int GetValue(int? value)
    {
        return value.HasValue ? value.Value : default(int);
    }
