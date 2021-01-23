    DataObject.AddPastingHandler(myRichTextBox, MyPasteCommand);
    DataObject.AddCopyingHandler(myRichTextBox, MyCopyCommand);
    private void MyPasteCommand(object sender, DataObjectEventArgs e)
    {
        //do stuff
    }
    private void MyCopyCommand(object sender, DataObjectEventArgs e)
    {
        //do stuff
    }
