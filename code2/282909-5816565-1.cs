    private List<string> _list = new List<string>();
    private List<string> ColList
    {
        get { return _list; }
        set { _list = value; }
    }
    
    private DataGridViewTextBoxColumn AddColumns(string Name)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                col.Name = Name;
                col.HeaderText = Name;
                col.HeaderCell.Style.WrapMode = DataGridViewTriState.NotSet;
                col.ToolTipText = Name;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;            
                col.MinimumWidth = 80;
                col.DataPropertyName =Name;            
                return col;
            }
