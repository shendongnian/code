    private DataRowView _CurRow = null;
    private DataTable _Tbl = null;
    private const string COL_NAME_ROW = "Row No.";
    private const string COL_NAME_FIRST = "First Name";
    private const string COL_NAME_LAST = "Last Name";
    public frmMain()
    {
      DataRow dr;
      InitializeComponent();
      _Tbl = new DataTable();
      _Tbl.Columns.Add(COL_NAME_ROW, typeof(int));
      _Tbl.Columns.Add(COL_NAME_FIRST, typeof(string));
      _Tbl.Columns.Add(COL_NAME_LAST, typeof(string));
      dr = _Tbl.NewRow();
      dr[COL_NAME_ROW] = 0;
      dr[COL_NAME_FIRST] = "Alan";
      dr[COL_NAME_LAST] = "Ladd";
      _Tbl.Rows.Add(dr);
      dr = _Tbl.NewRow();
      dr[COL_NAME_ROW] = 1;
      dr[COL_NAME_FIRST] = "Boris";
      dr[COL_NAME_LAST] = "Yeltsin";
      _Tbl.Rows.Add(dr);
      dr = _Tbl.NewRow();
      dr[COL_NAME_ROW] = 2;
      dr[COL_NAME_FIRST] = "Cab";
      dr[COL_NAME_LAST] = "Calloway";
      _Tbl.Rows.Add(dr);
      dr = _Tbl.NewRow();
      dr[COL_NAME_ROW] = 3;
      dr[COL_NAME_FIRST] = "David";
      dr[COL_NAME_LAST] = "Letterman";
      _Tbl.Rows.Add(dr);
      _Tbl.AcceptChanges();
    }
    private void frmMain_Shown(object sender, EventArgs e)
    {
      _CurRow = _Tbl.DefaultView[0];
      this.txtFirstName.DataBindings.Add("Text", _CurRow, COL_NAME_FIRST); //,
      //false, DataSourceUpdateMode.OnPropertyChanged);
      this.txtLastName.DataBindings.Add("Text", _CurRow, COL_NAME_LAST); //,
      //false, DataSourceUpdateMode.OnPropertyChanged);
      //this.nudRow.DataBindings.Add("Value", _Tbl, COL_NAME_ROW);
    }
    private void nudRow_ValueChanged(object sender, EventArgs e)
    {
      bool? hasChanged = null;
      // Previous row has modified (proposed) data here, but unchanged
      // RowState. Need to end or cancel the BeginEdit caused by
      // editing the bound control in order to update the RowState to
      // Modified and push Proposed value to Current (EndEdit) or
      // leave the RowState Unchanged (CancelEdit)
      hasChanged = this.RowHasChanged(_CurRow.Row);
      if (!hasChanged.HasValue)
      {
        // Didn't have proposed version so no-op
      }
      else if (hasChanged.Value)
      {
        _CurRow.Row.EndEdit();
      }
      else
      {
        _CurRow.Row.CancelEdit();
      }
      _CurRow = _Tbl.DefaultView[(int)this.nudRow.Value];
      this.txtFirstName.DataBindings.Clear();
      this.txtFirstName.DataBindings.Add("Text", _CurRow, COL_NAME_FIRST);
      this.txtLastName.DataBindings.Clear();
      this.txtLastName.DataBindings.Add("Text", _CurRow, COL_NAME_LAST);
    }
    // This is necessary because reverting values still causes
    // row to have proposed version, but isn't a true change
    private bool RowHasChanged(DataRow DataRowObj)
    {
      bool retVal = false;
      if (!DataRowObj.HasVersion(DataRowVersion.Proposed)) return retVal;
      for (int ii = 0; ii < _CurRow.Row.ItemArray.Length; ii++)
      {
        if (!object.Equals(
                _CurRow.Row[ii, DataRowVersion.Current],
                _CurRow.Row[ii, DataRowVersion.Proposed]))
        {
          retVal = true;
          break;
        }
      }
      if (!retVal.HasValue) retVal = false;
      return retVal;
    }
