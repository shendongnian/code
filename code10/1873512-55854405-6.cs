    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class CommaSeparatedAttribute : Attribute
    {
        public CommaSeparatedAttribute()
           : this(true)
        { }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="removeDuplicatedValues">remove duplicated values</param>
        public CommaSeparatedAttribute(bool removeDuplicatedValues)
        {
            RemoveDuplicatedValues = removeDuplicatedValues;
        }
        /// <summary>
        /// remove duplicated values???
        /// </summary>
        public bool RemoveDuplicatedValues { get; set; }
    }
