    [DataContract][Flags]
    public enum CarFeatures
    {
        None = 0,
        [EnumMember]
        AirConditioner = 1,
        [EnumMember]
        AutomaticTransmission = 2,
        [EnumMember]
        PowerDoors = 4,
        AlloyWheels = 8,
        DeluxePackage = AirConditioner | AutomaticTransmission | PowerDoors | AlloyWheels,
        [EnumMember]
        CDPlayer = 16,
        [EnumMember]
        TapePlayer = 32,
        MusicPackage = CDPlayer | TapePlayer,
        [EnumMember]
        Everything = DeluxePackage | MusicPackage
    }
