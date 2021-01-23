    public static void DataTableToCSV(DataTable Table, string Filename)
    {
        using(DataGridView dataGrid = new DataGridView())
        {
            // Save the current state of the clipboard so we can restore it after we are done
            IDataObject objectSave = Clipboard.GetDataObject();
            
            // Set the DataSource
            dataGrid.DataSource = Table;
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            // Select all the cells
            dataGrid.SelectAll();
            // Copy (set clipboard)
            Clipboard.SetDataObject(dataGrid.GetClipboardContent());
            // Paste (get the clipboard and serialize it to a file)
            File.WriteAllText(Filename,Clipboard.GetText(TextDataFormat.CommaSeparatedValue));				
            
            // Restore the current state of the clipboard so the effect is seamless
            if(objectSave != null) // If we try to set the Clipboard to an object that is null, it will throw...
            {
                Clipboard.SetDataObject(objectSave);
            }
        }
    }
