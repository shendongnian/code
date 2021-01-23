    /// <summary>
    /// Attribute to identify the Custom Proeprties.
    /// Only Proeprties marked with this attribute(true) will be displayed in property grid.
    /// </summary>
    [global::System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class IsCustomPropertyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        private bool isCustomProperty;
        public static readonly IsCustomPropertyAttribute Default = new IsCustomPropertyAttribute(false);
        public static readonly IsCustomPropertyAttribute No = new IsCustomPropertyAttribute(false);
        public static readonly IsCustomPropertyAttribute Yes = new IsCustomPropertyAttribute(true);
        /// <summary>
        /// Initializes a new instance of the <see cref="IsCustomPropertyAttribute"/> class.
        /// </summary>
        /// <param name="isCustomProperty">if set to <c>true</c> [is RT display property].</param>
        public IsCustomPropertyAttribute(bool isCustomProperty)
        {
            this.isCustomProperty = isCustomProperty;
        }
        /// <summary>
        /// Gets a value indicating whether this instance is RT display property.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is RT display property; otherwise, <c>false</c>.
        /// 	The default is false.
        /// </value>
        public bool IsCustomProperty
        {
            get { return isCustomProperty; }
            set { isCustomProperty = value; }
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            IsCustomPropertyAttribute attribute = obj as IsCustomPropertyAttribute;
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            return attribute.isCustomProperty == isCustomProperty;
        }
        public override int GetHashCode()
        {
            return isCustomProperty.GetHashCode();
        }
        public override bool IsDefaultAttribute()
        {
            return isCustomProperty == IsCustomPropertyAttribute.Default.isCustomProperty;
        }
    }
