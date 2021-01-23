    public class MyEditorClass
    {
        private readonly RichTextBox editor;
        private readonly TagClass tags;
        public TagClass Tags
        {
            get 
            {
                return tags; 
            } 
        }
    
        public MyEditorClass(RichTextBox editorBox)
        {
            editor = editorBox;
            tags = new TagClass(editorBox);
        }
    }
        
    public class TagClass
    {
        private RichTextBox _editor;
   
        internal TagClass(RichTextBox editor)
        {
            _editor = editor;
        }
        public void InsertTag1()
        {
            _editor.Text += "Test tag 1";
        }
     }
