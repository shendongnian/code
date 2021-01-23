    public sealed class NullObject {
        public static readonly NullObject Default = new NullObject();
        public static object GetNotNull( object value ) {
            return object.ReferenceEquals( value, null ) ? (object)Default : value;
        }
    }
    //....
    private object someField;
    public object SomeProperty {
        get { return NullObject.GetNotNull( this.someField ); }
    }
