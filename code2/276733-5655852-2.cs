    public class myRow
    {
        //your data storage class ... 
        public string txt { get; set; }
        public int id { get; set; }
    }
    public class MyView:ICustomTypeDescriptor
    {//your extendable view class ...
        private static PropertyDescriptorCollection props = null;
        static MyView()
        {
            TypeDescriptionProvider defaultProvider = TypeDescriptor.GetProvider(typeof(MyView));
            props = new PropertyDescriptorCollection(defaultProvider.GetTypeDescriptor(typeof(MyView)).GetProperties().Cast<PropertyDescriptor>().ToArray(), true);
        }
    
        public static void addProperty(string name, DataTable dt, Func<DataRow, object> getter, Action<DataRow, object> setter, Func<DataTable, MyView, DataRow> rowSelector, Type PropType)
        {
            List<PropertyDescriptor> tmp;
            if (props != null) tmp = props.Cast<PropertyDescriptor>().ToList();
            else tmp = new List<PropertyDescriptor>();
            PropertyDescriptor pd = TypeDescriptor.CreateProperty(typeof(MyView), name, PropType, null);
            pd = new MyViewPropertyDescriptor(pd, dt, getter, setter, rowSelector, PropType);
            tmp.Add(pd);
            props = new PropertyDescriptorCollection(tmp.ToArray(), true);
        }
    
        //the data storage obj this view is referencing
        public myRow obj;
    
        public string TXT { // view-member known at compile time
            get { return obj.txt; }
            set { obj.txt = value; }
        }
    
        internal class MyViewPropertyDescriptor : PropertyDescriptor
        {   // an example property descriptor that can link to data in a DataTable ... 
            DataTable dt;
            Func<DataRow, object> getter;
            Action<DataRow, object> setter;
            Func<DataTable, MyView, DataRow> rowSelector;
            Type type;
            public MyViewPropertyDescriptor(PropertyDescriptor descr, DataTable dt, Func<DataRow, object> getter, Action<DataRow, object> setter, Func<DataTable, MyView, DataRow> rowSelector, Type PropType)
                : base(descr)
            {
                this.dt = dt; // storage for additional data referenced by this property
                this.getter = getter; //a getter that will take a DataRow, and extract the property value
                this.setter = setter; //a setter that will take a DataRow and a value
                this.rowSelector = rowSelector;//a row selector ... takes a dataset and the view object and has to return the assiciated datarow
                this.type = PropType; // the type of this property
            }
    
            public override object GetValue(object component)
            {
                // using row selector and getter to return the current value ... you should add errorhandling here
                return getter(rowSelector(dt, (MyView)component));
            }
            public override void SetValue(object component, object value)
            {   // the setter ... needs errorhandling too
                setter(rowSelector(dt, (MyView)component), value);
            }
            public override void ResetValue(object component)
            {
    
            }
            public override bool CanResetValue(object component)
            {
                return false;
            }
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
            public override Type PropertyType
            {
                get { return type; }
            }
            public override bool IsReadOnly
            {
                get { return false; }
            }
            public override Type ComponentType
            {
                get { return typeof(MyView); }
            }
    
        }
    
        ICustomTypeDescriptor defaultDescriptor = TypeDescriptor.GetProvider(typeof(MyView)).GetTypeDescriptor(typeof(MyView));
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return defaultDescriptor.GetAttributes();
        }
        string ICustomTypeDescriptor.GetClassName()
        {
            return defaultDescriptor.GetClassName();
        }
        string ICustomTypeDescriptor.GetComponentName()
        {
            return defaultDescriptor.GetComponentName();
        }
        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return defaultDescriptor.GetConverter();
        }
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return defaultDescriptor.GetDefaultEvent();
        }
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return defaultDescriptor.GetDefaultProperty();
        }
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return defaultDescriptor.GetEditor(editorBaseType);
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return defaultDescriptor.GetEvents(attributes);
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return defaultDescriptor.GetEvents();
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return props; // should really be filtered, but meh!
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return props;
        }
        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    
    }
