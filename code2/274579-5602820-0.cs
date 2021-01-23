    [Serializable, StructLayout(LayoutKind.Sequential), TypeDependency("System.Collections.Generic.NullableComparer`1"), TypeDependency("System.Collections.Generic.NullableEqualityComparer`1")]
    public struct Nullable<T> where T: struct
    {
    
    private bool hasValue;
    internal T value;
    
    public Nullable(T value)
    {
        this.value = value;
        this.hasValue = true;
    }
    public bool HasValue
    {
        get
        {
            return this.hasValue;
        }
    }
    public T Value
    {
        get
        {
            if (!this.HasValue)
            {
                ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
            }
            return this.value;
        }
    }
    
    public T GetValueOrDefault()
    {
        return this.value;
    }
    public T GetValueOrDefault(T defaultValue)
    {
        if (!this.HasValue)
        {
            return defaultValue;
        }
        return this.value;
    }
    public override bool Equals(object other)
    {
        if (!this.HasValue)
        {
            return (other == null);
        }
        if (other == null)
        {
            return false;
        }
        return this.value.Equals(other);
    }
    public override int GetHashCode()
    {
        if (!this.HasValue)
        {
            return 0;
        }
        return this.value.GetHashCode();
    }
    public override string ToString()
    {
        if (!this.HasValue)
        {
            return "";
        }
        return this.value.ToString();
    }
    public static implicit operator T?(T value)
    {
        return new T?(value);
    }
    public static explicit operator T(T? value)
    {
        return value.Value;
    }
    }
