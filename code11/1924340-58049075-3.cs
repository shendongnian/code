    public enum UnitType
    {
        Second,
        Microsecond,
        Millisecond,
        Minute,
        Hour,
        Day,
        Week
    }
   
    public class Unit
    {
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public double Factor { get; private set; }
        public Unit Base { get; private set; }
        public Unit(UnitType unit, bool isBase = false)
        {
            Name = GetUnitName(unit);
            Symbol = GetUnitSymbol(unit);
            Factor = GetUnitFactor(unit);
            
            if (!isBase)
                Base = GetUnitBase(unit);
        }
        private string GetUnitName(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Second:
                    return "second";
                case UnitType.Microsecond:
                    return "microsecond";
                case UnitType.Millisecond:
                    return "millisecond";
                case UnitType.Minute:
                    return "minute";
                case UnitType.Hour:
                    return "hour";
                case UnitType.Day:
                    return "day";
                case UnitType.Week:
                    return "week";
                default:
                    return null;
            }
        }
        private string GetUnitSymbol(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Second:
                    return "s";
                case UnitType.Microsecond:
                    return "μs";
                case UnitType.Millisecond:
                    return "ms";
                case UnitType.Minute:
                    return "min";
                case UnitType.Hour:
                    return "h";
                case UnitType.Day:
                    return "d";
                case UnitType.Week:
                    return "w";
                default:
                    return null;
            }
        }
        private double GetUnitFactor(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Second:
                    return 1;
                case UnitType.Microsecond:
                    return 0.000001;
                case UnitType.Millisecond:
                    return 0.001;
                case UnitType.Minute:
                    return 60.0;
                case UnitType.Hour:
                    return 3600.0;
                case UnitType.Day:
                    return 24.0;
                case UnitType.Week:
                    return 7;
                default:
                    return 0;
            }
        }
        private Unit GetUnitBase(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Microsecond:
                    return new Unit(UnitType.Second, true);
                case UnitType.Millisecond:
                    return new Unit(UnitType.Second, true);
                case UnitType.Minute:
                    return new Unit(UnitType.Second, true);
                case UnitType.Hour:
                    return new Unit(UnitType.Minute, true);
                case UnitType.Day:
                    return new Unit(UnitType.Hour, true);
                case UnitType.Week:
                    return new Unit(UnitType.Day, true);
                default:
                    return null;
            }
        }
    }
