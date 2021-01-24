    [System.ComponentModel.TypeConverter(typeof(PositionConverter))]
    public struct Position 
    {
        ...
        public static Position Parse(string positionString)
        {
            ...
        }
    }
