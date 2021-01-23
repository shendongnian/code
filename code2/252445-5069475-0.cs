    public interface IEditorFactory<TObject>
    {
        Editor CreateEditor(TObject instance);
    }
    public interface ITabEditorFactory<TObject>
    {
        void CreateTab(TObject instance, Editor parent);
    }
