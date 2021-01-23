    public class UserControl1 : UserControl
    {
        private Collection<Class1> field = new Collection<Class1>();
    
        [Category("Data")]
        [DefaultValue(null)]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<Class1> prop
        {
            get { return field; }
        }
    }
