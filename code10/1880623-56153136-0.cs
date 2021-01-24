    public enum GenericUnitType {
        BASIC, 
        NORMAL,
        HERO;
    }
    
    public class UnitType
    {
        public static GenericUnitType CLOSE_BASIC = new UnitType(GenericUnitType.BASIC);
        public static GenericUnitType DISTANCE_BASIC = new UnitType(GenericUnitType.BASIC),
        public static GenericUnitType CLOSE_NORMAL = new UnitType(GenericUnitType.NORMAL),
        public static GenericUnitType DISTANCE_NORMAL = new UnitType(GenericUnitType.NORMAL),
        public static GenericUnitType HERO_CLOSE_FIGHTER = new UnitType(GenericUnitType.HERO),
        public static GenericUnitType HERO_DISTANCE_FIGHTER = new UnitType(GenericUnitType.HERO);
    
        private GenericUnitType _unitType;
    
        public UnitType(GenericUnitType unitType)
        {
            _unitType = unitType;
        }
    
        public GenericUnitType UnitType => _unitType;
    }
