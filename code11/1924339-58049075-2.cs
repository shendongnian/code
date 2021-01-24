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
        public static implicit operator double(Unit v) => v.Factor;
        public static implicit operator string(Unit v) => v.Name.Short;
    }
