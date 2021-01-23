    class FullscreenCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        protected override CollectionForm CreateCollectionForm()
        {
            var editor = base.CreateCollectionForm();
            editor.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            return editor; 
        }
        public FullscreenCollectionEditor(Type type) : base(type)
        {
        }
    }
