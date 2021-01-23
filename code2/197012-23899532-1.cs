    public class MyCustomAttribute: Attribute
    {
        private Nullable<bool> myBoolean = null;
        public bool MyBooleanProperty { get { return this.myBoolean.GetValueOrDefault(); } set { this.myBoolean = value; } }
        public bool IsMyBooleanPropertySpecified { get { return this.myBoolean != null; } }
    }
