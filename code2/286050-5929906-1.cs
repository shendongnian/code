    public class NameTypeEditor : System.ComponentModel.Design.CollectionEditor
    {
        public NameTypeEditor(Type t)
            : base(t)
        {
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext   context, IServiceProvider provider, object value)
        {
            return base.EditValue(context, provider, value);
        }
    }
