    class EditableText : UserControl
    {
        private LinkLabel lblName;
        private TextBox txtName;
        public EditableText()
        {
            // Construct objects, attach events and add them
            // as children to this object
        }
        // Return the text of encapsulated TextBox
        public string Text
        {
           get { return txtName.Text; }
        }
    }
