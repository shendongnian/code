        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class UnitTypeAttribute : Attribute
    {
        public UnitType UnitType{ get; set; }
        public UnitAttribute(UnitType unitT)
        {
            UnitType= unitT;
        }
    }
}
