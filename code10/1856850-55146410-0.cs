    private void copyButton_Click(object sender, EventArgs e)
        {
            DataFormats.Format myFormat = DataFormats.GetFormat("test4.copypaste");
            var copy_obj = new copypaste();
            DataObject myDataObject = new DataObject(myFormat.Name, copy_obj);
            Clipboard.SetDataObject(myDataObject);
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            var d = Clipboard.GetDataObject();
            if (d.GetDataPresent("test4.copypaste"))
            {
                var o = d.GetData("test4.copypaste");
                Debug.WriteLine(((copypaste)o).test);
            }
        }
