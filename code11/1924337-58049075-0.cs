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
    public class UnitName
    {
        public string Long { get; set; }
        public string Short { get; set; }
    }
    public class Unit
    {
        private UnitBase _base;
        public Unit(UnitType unit)
        {
            Type = unit;
            _base = new UnitBase(this);
        }
        public UnitType Type { get; private set; }
        public UnitName Name => _base.Name;
        public double Factor => _base.Factor;
        public UnitBase Base => GetBaseUnit(Type);
        private UnitBase GetBaseUnit(UnitType unit)
        {
            if (unit == UnitType.Day)
                return new UnitBase(new Unit(UnitType.Hour));
            else if (unit == UnitType.Week)
                return new UnitBase(new Unit(UnitType.Day));
            else
                return new UnitBase(new Unit(UnitType.Second));
        }
    }
    public class UnitBase
    {
        public UnitName Name { get; set; }
        public double Factor { get; set; }
        public UnitBase(Unit unit)
        {
            Name = new UnitName
            {
                Long = GetUnitNameLong(unit.Type),
                Short = GetUnitShortName(unit.Type)
            };
            Factor = GetUnitFactor(unit.Type);
        }
        private string GetUnitNameLong(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Second:
                    return UnitType.Second.ToString().ToLower();
                case UnitType.Microsecond:
                    return UnitType.Microsecond.ToString().ToLower();
                case UnitType.Millisecond:
                    return UnitType.Millisecond.ToString().ToLower();
                case UnitType.Minute:
                    return UnitType.Minute.ToString().ToLower();
                case UnitType.Hour:
                    return UnitType.Hour.ToString().ToLower();
                case UnitType.Day:
                    return UnitType.Day.ToString().ToLower();
                case UnitType.Week:
                    return UnitType.Week.ToString().ToLower();
                default:
                    return null;
            }
        }
        private string GetUnitShortName(UnitType unit)
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
    }
