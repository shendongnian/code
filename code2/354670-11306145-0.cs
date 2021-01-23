    private void TextBoxPaste(object sender, DataObjectPastingEventArgs e) {
            string text = (String)e.DataObject.GetData(typeof(String));
            DataObject d = new DataObject();
            d.SetData(DataFormats.Text, text.Replace(Environment.NewLine, " "));
            e.DataObject = d;
     }
