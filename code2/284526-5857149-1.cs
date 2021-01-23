    public class Customer
    {
        [DefaultValue(null)]
        public string SomeInfo { get; set; }
        [DefaultValue(null)]
        public string SomeOtherInfo { get; set; }
        #region Serialization conditions
        // should SomeInfo be serialized?
        public bool ShouldSerializeSomeInfo()
        {
             return SomeInfo != null; // serialize if not null
        }
        // should SomeOtherInfo be serialized?
        public bool ShouldSerializeSomeOtherInfo()
        {
             return SomeOtherInfo != null; // serialize if not null
        }
        #endregion
    }
