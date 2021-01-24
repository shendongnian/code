        //
    // Summary:
    //     Indicating whether a property is required.
    public enum Required
    {
        //
        // Summary:
        //     The property is not required. The default state.
        Default = 0,
        //
        // Summary:
        //     The property must be defined in JSON but can be a null value.
        AllowNull = 1,
        //
        // Summary:
        //     The property must be defined in JSON and cannot be a null value.
        Always = 2,
        //
        // Summary:
        //     The property is not required but it cannot be a null value.
        DisallowNull = 3
    }
