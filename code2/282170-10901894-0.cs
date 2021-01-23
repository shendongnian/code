        [Description("Note displayed with star icons"), 
        Category("Data"),
        Browsable(true), 
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Note
        {
            get { return (int)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); /* don't put anything more here */ }
        }
