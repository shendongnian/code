    private void DataForm_EditEnding(object sender, DataFormEditEndingEventArgs e)
    {
        if (e.EditAction == DataFormEditAction.Commit)
        {
            ...
        }
        else
        {
            DataForm1.ValidationSummary.Errors.Clear();
        }
    }
