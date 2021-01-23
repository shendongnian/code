    public class ControlLimit
    {
        public int ControlLimitId { get; set; }
        public string ControlLimitDesc { get; set; }
        public float ControlLimitLow { get; set; }
        public float ControlLimitHigh { get; set; }
    } 
    private void OnEndEdit(object sender, DataGridCellEditEndingEventArgs e)
    {
        //Get the cell info, which is old, then assign the new info 
        var cellInfo = (ControlLimit)(((System.Windows.Controls.DataGrid) sender).CurrentCell).Item;
        var editingElementPram = float.Parse(((System.Windows.Controls.TextBox) e.EditingElement).Text);
        if (e.Column.Header.ToString() == "Low Limit")
            cellInfo.ControlLimitLow = editingElementPram;
        else if (e.Column.Header.ToString() == "High Limit")
            cellInfo.ControlLimitHigh = editingElementPram;
        var controlLimitId = ControlLimit.UpdateControlLimitParameters(cellInfo);
    }
