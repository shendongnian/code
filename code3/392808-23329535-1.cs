    // Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        if (context.ToString() == "Parsing, Commit")
        {
            // Do something here
        }
        return EditingControlFormattedValue;
    }
