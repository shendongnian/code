    [Flags] 
    public enum FlagsEnum {
       None = 0,
       One = 1,
       Two = 2,
       Three = 4,
    }
    
    void Main()
    {
        var flags = FlagsEnum.Two;
        var hasOneElement = Enum.GetValues(typeof(FlagsEnum)).OfType<FlagsEnum>().Where(i => i != 0 && flags.HasFlag(i)).Count() == 1;
    }
