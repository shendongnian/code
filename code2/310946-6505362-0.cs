        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, 
                 System.Design, Version=2.0.0.0, Culture=neutral, 
                 PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public StringCollection Items
        {
            get { return _myStringCollection; }
        }
