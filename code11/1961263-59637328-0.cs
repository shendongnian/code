    public static class Utility
    {
        private static Lazy<UtilityObject> _myUtil = null;
        private static Utility()
        {
            _myUtil = new Lazy<UtilityObject>( () => new UtilityObject(ConfigContext.myValue) );
        }
        public static myUtil => _myUtil.Value;
    }
