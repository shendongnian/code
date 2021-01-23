    void Ctrl_KeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
        {
            e.SuppressKeyPress = e.Handled = EditAppend(ClipboardAsDataRow);
        }
    }
    public bool EditAppend(IEnumerable<DataRow> rows)
    {
        try
        {
            // whatever is your datasourse... 
            DataTable dt = new DataTable;
            foreach (DataRow row in rows)
            {
                dt.LoadDataRow(row.ItemArray, LoadOption.Upsert);
            }
            return true;    
        }
        catch ()
        {
            return false;
        }
    }
    /// <summary>
    /// Get Clipboard as DataRows
    /// </summary>
    public IEnumerable<DataRow> ClipboardAsDataRow
    {
    get
        {
            DataTable dt = new DataTable();
            IDataObject iData = Clipboard.GetDataObject();
            if (iData == null || !iData.GetDataPresent(DataFormats.Text)) return dt.Rows.Cast<DataRow>();
            
            string table = (string)iData.GetData(DataFormats.Text);
            foreach (string row in value.Split("\n".ToCharArray()))
            {
                dt.LoadDataRow(row.Split("\r\x09".ToCharArray()), true);
            }
            return dt.Rows.Cast<DataRow>();
        } 
    }
