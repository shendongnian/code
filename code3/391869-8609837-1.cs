    class EnumDictionary<EnumType, ValueType>
    {
        private readonly ValueType[] array = new ValueType[Enum.GetValues(typeof(EnumType)).Length];
        public ValueType this[EnumType index]
        {
            get { return array[Convert.ToInt32(index)]; }
            set { array[Convert.ToInt32(index)] = value; }
        }
    }
    EnumDictionary<EMyEnum, string> enumDictionary = new EnumDictionary<EMyEnum, string>();
    foreach ( EMyEnum myEnum in Enum.GetValues(typeof(EnumType))
        enumDictionary[myEnum] = "";
