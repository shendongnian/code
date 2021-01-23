    /// <summary>
    /// Attribute to identify the Custom Proeprties.
    /// Only Proeprties marked with this attribute(true) will be displayed in property grid.
    /// </summary>
    [global::System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IsCustomPropertyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        private bool isCustomProperty;
        public IsCustomPropertyAttribute(bool isCustomProperty)
        {
            this.isCustomProperty = isCustomProperty;
        }
        public bool IsCustomProperty
        {
            get { return isCustomProperty; }
            set { isCustomProperty = value; }
        }
        public override bool IsDefaultAttribute()
        {
            return isCustomProperty == false;
        }
    }
