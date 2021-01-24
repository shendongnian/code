MyDataFile.SetValue("AutoresizeTableColumns", MyFillColumnsItem.Checked);
and move most of the code related to this setting to MainForm's setting application method:
case "AutoresizeTableColumns":
    ClockDataGridView cdgv = MyClocksViewProvider.GetExistingOrNewClockDataGridView();
    if (!cdgv.FirstParentChange)
    {
        cdgv.MyFillColumnsItem.Checked =
            (bool)MyDataFile.GetValue("AutoresizeTableColumns");
        if (cdgv.MyFillColumnsItem.Checked)
        {
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                cdgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            cdgv.Columns[(int)ClockDataGridView.TimerColumns.Tag].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                DataGridViewColumn col = cdgv.Columns[i];
            }
        }
        else
        {
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                cdgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
    }
    else
    {
        cdgv.ParentChanged += Cdgv_ParentChanged;
    }
    break;
Finally:
    internal void Cms_ResizeColumnsToFill(object sender, EventArgs e)
    {
        MyDataFile.SetValue("AutoresizeTableColumns", MyFillColumnsItem.Checked);
    }
and:
    private void Cdgv_ParentChanged(object sender, EventArgs e)
    {
        ClockDataGridView cdgv = MyClocksViewProvider.GetExistingOrNewClockDataGridView();
        if (cdgv.MyFillColumnsItem.Checked)
        {
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                cdgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            cdgv.Columns[(int)ClockDataGridView.TimerColumns.Tag].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                DataGridViewColumn col = cdgv.Columns[i];
            }
        }
        else
        {
            for (int i = 0; i < cdgv.Columns.Count; ++i)
            {
                cdgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
        cdgv.ParentChanged -= Cdgv_ParentChanged;
    }
