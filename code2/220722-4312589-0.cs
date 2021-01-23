    public class TagClass
    {
        private MyEditorClass editor = null;
        
        public TagClass(MyEditorClass parent)
        {
            this.editor = parent;
        }
        
        public void InsertTag1()
        {
            editor.Text += "Test tag 1";
        }
    }
    
    ...
    
    Tags = new TagClass(this);
