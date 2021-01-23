    public class CustomCollectionModalEditor: UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context ==null || context.Instance == null)                
                return base.GetEditStyle(context);
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            if (context == null || context.Instance == null || provider == null)
                return value;
            editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            CForm CollectionEditor = new CForm();
            if (editorService.ShowDialog(CollectionEditor) == System.Windows.Forms.DialogResult.OK)
                return CollectionEditor.Programmed;
            return value;
            //return base.EditValue(context, provider, value);
        }
    }
