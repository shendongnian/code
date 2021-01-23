    class ObjectBucket {
        object foo;
        [Editor(typeof(ObjectUITypeEditor), typeof(UITypeEditor))]
        public object Object {
            get { return foo; }
            set { foo = value; }
        }
    }
    //...
    class ObjectUIEditor : Form {
        public ObjectUIEditor(object editValue) {
            /* TODO Initialize editor*/
        }
        public object EditValue {
            get { return null; /* TODO GetValue from editor */} 
        }
    }
    //...
    class ObjectUITypeEditor : System.Drawing.Design.UITypeEditor {
        System.Windows.Forms.Design.IWindowsFormsEditorService edSvc = null;
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object objValue)
            if(context != null && context.Instance != null && provider != null) {
                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if(edSvc != null) {
                    try {
                        ObjectUIEditor editor = new ObjectUIEditor(objValue);
                        if(edSvc.ShowDialog(editor) == DialogResult.OK) 
                            objValue = editor.EditValue;
                    }
                    catch { }
                }
            }
            return objValue;
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            if(context != null && context.Instance != null) 
                return UITypeEditorEditStyle.Modal;
            return base.GetEditStyle(context);
        }
    }
