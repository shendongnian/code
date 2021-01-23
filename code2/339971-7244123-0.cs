     DataObject.AddPastingHandler(doc.Editor, new DataObjectPastingEventHandler(OnPaste));
     DataObject.AddCopyingHandler(doc.Editor, new DataObjectCopyingEventHandler(OnCopy));
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        { 
        }
        private void OnCopy(object sender, DataObjectCopyingEventArgs e)
        {
        }
