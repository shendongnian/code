    public class SomeTypeEditor : CollectionEditor {
        public SomeTypeEditor(Type type) : base(type) { }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            object result = base.EditValue(context, provider, value);
            // assign the temporary collection from the UI to the property
            ((ClassContainingStuffProperty)context.Instance).Stuff = (List<SomeType>)result;
            return result;
        }
    }
