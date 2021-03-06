    public bool HasFlag(Enum flag)
    {
        if (!this.GetType().IsEquivalentTo(flag.GetType())) {
            throw new ArgumentException(Environment.GetResourceString("Argument_EnumTypeDoesNotMatch", flag.GetType(), this.GetType())); 
        }
 
        ulong uFlag = ToUInt64(flag.GetValue()); 
        ulong uThis = ToUInt64(GetValue());
        return ((uThis & uFlag) == uFlag); 
    }
