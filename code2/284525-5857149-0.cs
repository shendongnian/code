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
             return _someInfo != null; // serialize if not null
        }
        // should SomeOtherInfobe serialized?
        public bool ShouldSerializeSomeOtherInfo()
        {
             return _someInfo != null; // serialize if not null
        }
        #endregion
    }
