    public enum ECountry : long
    {
        None,
        Canada,
        UnitedStates = (long)int.MaxValue + 1;
    }
    // val will be equal to the *long* value int.MaxValue + 1
    long val = (long)ECountry.UnitedStates;
