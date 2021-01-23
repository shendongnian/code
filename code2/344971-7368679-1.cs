    public bool HasFlag(Enum flag)
    {
        if (!base.GetType().IsEquivalentTo(flag.GetType()))
        {
            throw new ArgumentException(Environment.GetResourceString("Argument_EnumTypeDoesNotMatch", new object[] { flag.GetType(), base.GetType() }));
        }
        ulong num = ToUInt64(flag.GetValue());
        return ((ToUInt64(this.GetValue()) & num) == num);
    }
    
